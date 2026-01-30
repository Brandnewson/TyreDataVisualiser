using Microsoft.EntityFrameworkCore;

namespace TyreDataVisualiser.Data;

/// <summary>
/// Represents a single tire test run with metadata
/// Links the hard-coded test metadata with telemetry data from the .dat files
/// </summary>
public class TestRun
{
    public int Id { get; set; }
    public int Round { get; set; }
    public int RunNumber { get; set; }
    public string TyreBrand { get; set; } = string.Empty;
    public string TyreModel { get; set; } = string.Empty;
    public int RimDiameter { get; set; }
    public double RimWidth { get; set; }
    public string TestCondition { get; set; } = string.Empty;
    
    // Metadata from .dat file header
    public string ProjectId { get; set; } = string.Empty;
    public DateTime TestDate { get; set; }
    public TimeSpan TestTime { get; set; }
    public string DataFileId { get; set; } = string.Empty;
    public bool IsoMode { get; set; }
    
    // Relationships
    public ICollection<TelemetryDataPoint> DataPoints { get; set; } = new List<TelemetryDataPoint>();
}

/// <summary>
/// Represents a single telemetry data point (one row of measurements from the .dat file)
/// Contains all measured values at a specific point in time during the test
/// </summary>
public class TelemetryDataPoint
{
    public int Id { get; set; }
    
    // Foreign key
    public int TestRunId { get; set; }
    public TestRun? TestRun { get; set; }
    
    // Telemetry measurements (columns from .dat file)
    public double ET { get; set; }               // Elapsed time (s)
    public double V { get; set; }                // Velocity (kph)
    public double N { get; set; }                // RPM
    public double SA { get; set; }               // Slip angle (deg)
    public double IA { get; set; }               // Inclination angle (deg)
    public double RL { get; set; }               // Left radius (cm)
    public double RE { get; set; }               // Right radius (cm)
    public double P { get; set; }                // Pressure (kPa)
    public double FX { get; set; }               // Longitudinal force (N)
    public double FY { get; set; }               // Lateral force (N)
    public double FZ { get; set; }               // Vertical force (N)
    public double MX { get; set; }               // Moment X (Nm)
    public double MZ { get; set; }               // Moment Z (Nm)
    public double NFX { get; set; }              // Normalized FX
    public double NFY { get; set; }              // Normalized FY
    public double RST { get; set; }              // Slip angle temperature (deg C)
    public double TSTI { get; set; }             // Tire inlet temperature (deg C)
    public double TSTC { get; set; }             // Tire center temperature (deg C)
    public double TSTO { get; set; }             // Tire outlet temperature (deg C)
    public double AmbTmp { get; set; }           // Ambient temperature (deg C)
    public double SR { get; set; }               // Slip ratio (SAE)
}

public class Tyre
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Size { get; set; }
}

public class TyreContext : DbContext
{
    public TyreContext(DbContextOptions<TyreContext> options) : base(options)
    {
    }
    
    public DbSet<Tyre> Tyres => Set<Tyre>();
    public DbSet<TestRun> TestRuns => Set<TestRun>();
    public DbSet<TelemetryDataPoint> TelemetryDataPoints => Set<TelemetryDataPoint>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // TestRun configuration
        modelBuilder.Entity<TestRun>()
            .HasKey(t => t.Id);
        
        modelBuilder.Entity<TestRun>()
            .HasIndex(t => new { t.Round, t.RunNumber, t.TestCondition })
            .IsUnique();

        // TelemetryDataPoint configuration
        modelBuilder.Entity<TelemetryDataPoint>()
            .HasKey(t => t.Id);
        
        modelBuilder.Entity<TelemetryDataPoint>()
            .HasOne(d => d.TestRun)
            .WithMany(r => r.DataPoints)
            .HasForeignKey(d => d.TestRunId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TelemetryDataPoint>()
            .HasIndex(d => d.TestRunId);
    }
}