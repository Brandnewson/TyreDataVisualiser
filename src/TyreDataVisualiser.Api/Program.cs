using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using TyreDataVisualiser.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => options.AddPolicy("AllowFrontend", policy =>
    policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TyreContext>(options =>
    options.UseSqlite("Data Source=tyres.db")); // SQLite connection string

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
// Disable HTTPS redirection in development for easier testing
// app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");


app.MapGet("/tyres", async (TyreContext db) =>
    await db.Tyres.ToListAsync());

// Folder upload endpoint
app.MapPost("/api/upload", async (HttpRequest request, TyreContext db) =>
{
    if (!request.HasFormContentType)
        return Results.BadRequest("No form data.");
    var files = request.Form.Files;
    if (files.Count == 0)
        return Results.BadRequest("No files uploaded.");

    var uploadResults = new List<object>();

    foreach (var file in files)
    {
        try
        {
            // Extract round and run number from filename (e.g., "B1965raw1.dat" -> round 8, run 1; "B1654raw5.dat" -> round 6, run 5)
            var (round, runNumber) = TyreDataVisualiser.Data.TyreTestMappingService.ExtractRoundAndRunNumber(file.FileName);
            
            if (round == 0 || runNumber == -1)
            {
                Console.WriteLine($"WARNING: Could not extract round/run number from: {file.FileName}");
                uploadResults.Add(new { fileName = file.FileName, success = false, error = "Could not extract round/run number" });
                continue;
            }
            
            // Get test metadata for this round and run
            var metadataList = TyreDataVisualiser.Data.TyreTestMappingService.GetTestMetadata(round, runNumber).ToList();
            
            if (!metadataList.Any())
            {
                Console.WriteLine($"WARNING: No mapping found for round {round} run number {runNumber} ({file.FileName})");
                uploadResults.Add(new { fileName = file.FileName, success = false, error = "No metadata mapping found" });
                continue;
            }
            
            // Read and parse the .dat file
            string fileContent;
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                fileContent = await reader.ReadToEndAsync();
            }

            var (datHeader, dataPoints) = TyreDataVisualiser.Data.DatFileParser.ParseDatFile(fileContent);

            Console.WriteLine($"Received: {file.FileName} ({file.Length} bytes)");
            Console.WriteLine($"  Round: {round}");
            Console.WriteLine($"  Run #: {runNumber}");
            Console.WriteLine($"  Project: {datHeader.ProjectId}");
            Console.WriteLine($"  Date: {datHeader.TestDate:MM-dd-yyyy} Time: {datHeader.TestTime}");
            Console.WriteLine($"  Data points parsed: {dataPoints.Count}");
            Console.WriteLine($"  Found {metadataList.Count} test condition(s):");
            
            // Store data for each test condition
            foreach (var metadata in metadataList)
            {
                var testRun = new TestRun
                {
                    Round = round,
                    RunNumber = runNumber,
                    TyreBrand = metadata.TyreBrand,
                    TyreModel = metadata.TyreModel,
                    RimDiameter = metadata.RimDiameter,
                    RimWidth = metadata.RimWidth,
                    TestCondition = metadata.TestCondition,
                    ProjectId = datHeader.ProjectId,
                    TestDate = datHeader.TestDate,
                    TestTime = datHeader.TestTime,
                    DataFileId = datHeader.DataFileId,
                    IsoMode = datHeader.IsoMode,
                    DataPoints = dataPoints
                };

                db.TestRuns.Add(testRun);
                Console.WriteLine($"    - Test Condition: {metadata.TestCondition}");
                Console.WriteLine($"      Rim Diameter: {metadata.RimDiameter}");
                Console.WriteLine($"      Brand: {metadata.TyreBrand}");
                Console.WriteLine($"      Model: {metadata.TyreModel}");
                Console.WriteLine($"      Rim Width: {metadata.RimWidth}");
            }

            // Save all changes to database
            await db.SaveChangesAsync();
            uploadResults.Add(new { fileName = file.FileName, success = true, dataPointsStored = dataPoints.Count, testConditionsCreated = metadataList.Count });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR processing {file.FileName}: {ex.Message}");
            uploadResults.Add(new { fileName = file.FileName, success = false, error = ex.Message });
        }
    }

    return Results.Ok(new { count = files.Count, results = uploadResults });
});

// Get all test runs with summary info
app.MapGet("/api/test-runs", async (TyreContext db) =>
{
    var testRuns = await db.TestRuns
        .Select(tr => new
        {
            tr.Id,
            tr.Round,
            tr.RunNumber,
            tr.TyreBrand,
            tr.TyreModel,
            tr.RimDiameter,
            tr.RimWidth,
            tr.TestCondition,
            tr.ProjectId,
            TestDate = tr.TestDate.ToString("MM-dd-yyyy"),
            TestTime = tr.TestTime.ToString(@"hh\:mm"),
            tr.DataFileId,
            DataPointCount = tr.DataPoints.Count
        })
        .OrderBy(tr => tr.Round)
        .ThenBy(tr => tr.RunNumber)
        .ToListAsync();

    return Results.Ok(testRuns);
});

// Get specific test run with all telemetry data
app.MapGet("/api/test-runs/{id}", async (int id, TyreContext db) =>
{
    var testRun = await db.TestRuns
        .Include(tr => tr.DataPoints)
        .FirstOrDefaultAsync(tr => tr.Id == id);

    if (testRun == null)
        return Results.NotFound(new { error = "Test run not found" });

    return Results.Ok(new
    {
        testRun.Id,
        testRun.Round,
        testRun.RunNumber,
        testRun.TyreBrand,
        testRun.TyreModel,
        testRun.RimDiameter,
        testRun.RimWidth,
        testRun.TestCondition,
        testRun.ProjectId,
        TestDate = testRun.TestDate.ToString("MM-dd-yyyy"),
        TestTime = testRun.TestTime.ToString(@"hh\:mm"),
        testRun.DataFileId,
        testRun.IsoMode,
        DataPoints = testRun.DataPoints.Select(dp => new
        {
            dp.ET, dp.V, dp.N, dp.SA, dp.IA, dp.RL, dp.RE, dp.P,
            dp.FX, dp.FY, dp.FZ, dp.MX, dp.MZ, dp.NFX, dp.NFY,
            dp.RST, dp.TSTI, dp.TSTC, dp.TSTO, dp.AmbTmp, dp.SR
        }).ToList()
    });
});

// Get database statistics
app.MapGet("/api/stats", async (TyreContext db) =>
{
    var stats = new
    {
        totalTestRuns = await db.TestRuns.CountAsync(),
        totalDataPoints = await db.TelemetryDataPoints.CountAsync(),
        testRunsByRound = await db.TestRuns
            .GroupBy(tr => tr.Round)
            .Select(g => new { round = g.Key, count = g.Count() })
            .ToListAsync(),
        testRunsByCondition = await db.TestRuns
            .GroupBy(tr => tr.TestCondition)
            .Select(g => new { condition = g.Key, count = g.Count() })
            .OrderByDescending(x => x.count)
            .ToListAsync()
    };

    return Results.Ok(stats);
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
