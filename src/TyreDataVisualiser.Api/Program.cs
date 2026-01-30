using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using TyreDataVisualiser.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => options.AddPolicy("AllowFrontend", policy =>
    policy.WithOrigins("http://localhost:5173")
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
app.UseHttpsRedirection();

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
app.MapPost("/api/upload", async (HttpRequest request) =>
{
    if (!request.HasFormContentType)
        return Results.BadRequest("No form data.");
    var files = request.Form.Files;
    if (files.Count == 0)
        return Results.BadRequest("No files uploaded.");

    foreach (var file in files)
    {
        // Extract round and run number from filename (e.g., "B1965raw1.dat" -> round 8, run 1; "B1654raw5.dat" -> round 6, run 5)
        var (round, runNumber) = TyreDataVisualiser.Data.TyreTestMappingService.ExtractRoundAndRunNumber(file.FileName);
        
        if (round == 0 || runNumber == -1)
        {
            Console.WriteLine($"WARNING: Could not extract round/run number from: {file.FileName}");
            continue;
        }
        
        // Get test metadata for this round and run
        var metadataList = TyreDataVisualiser.Data.TyreTestMappingService.GetTestMetadata(round, runNumber).ToList();
        
        if (!metadataList.Any())
        {
            Console.WriteLine($"WARNING: No mapping found for round {round} run number {runNumber} ({file.FileName})");
            continue;
        }
        
        Console.WriteLine($"Received: {file.FileName} ({file.Length} bytes)");
        Console.WriteLine($"  Round: {round}");
        Console.WriteLine($"  Run #: {runNumber}");
        Console.WriteLine($"  Found {metadataList.Count} test condition(s):");
        
        foreach (var metadata in metadataList)
        {
            Console.WriteLine($"    - Test Condition: {metadata.TestCondition}");
            Console.WriteLine($"      Rim Diameter: {metadata.RimDiameter}");
            Console.WriteLine($"      Brand: {metadata.TyreBrand}");
            Console.WriteLine($"      Model: {metadata.TyreModel}");
            Console.WriteLine($"      Rim Width: {metadata.RimWidth}");
        }
    }
    return Results.Ok(new { count = files.Count });
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
