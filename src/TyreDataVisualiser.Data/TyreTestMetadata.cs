namespace TyreDataVisualiser.Data;

/// <summary>
/// Represents metadata for a specific tyre test run
/// Each run tests a specific tire/rim configuration under a specific condition
/// </summary>
public class TyreTestMetadata
{
    public int RunNumber { get; set; }
    public int RimDiameter { get; set; }
    public string TyreBrand { get; set; } = string.Empty;
    public string TyreModel { get; set; } = string.Empty;
    public double RimWidth { get; set; }
    public string TestCondition { get; set; } = string.Empty; // Transient, Initial 12 psi, 10,14 psi, 8 psi, Final 12 psi, Speed test
}

/// <summary>
/// Service to map run numbers from filenames to test metadata
/// Hardcoded mapping based on the provided test configuration
/// </summary>
public class TyreTestMappingService
{
    private static readonly List<TyreTestMetadata> TestMappings = new()
    {
        // Row 1: Rim 10, Hoosier 43075 16x7.5-10 R25B, Width 7
        new TyreTestMetadata { RunNumber = 1, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { RunNumber = 2, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { RunNumber = 2, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { RunNumber = 4, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { RunNumber = 4, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { RunNumber = 4, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 7, TestCondition = "Speed test" },
        // Row 2: Rim 10, Hoosier 43075 16x7.5-10 R25B, Width 8
        new TyreTestMetadata { RunNumber = 5, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 8, TestCondition = "Transient" },
        new TyreTestMetadata { RunNumber = 6, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 8, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { RunNumber = 6, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 8, TestCondition = "10,14 psi" },
        new TyreTestMetadata { RunNumber = 7, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 8, TestCondition = "8 psi" },
        new TyreTestMetadata { RunNumber = 7, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 8, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { RunNumber = 7, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 8, TestCondition = "Speed test" },
        // Row 3: Rim 10, Hoosier 43070 16x6.0-10 R25B, Width 6
        new TyreTestMetadata { RunNumber = 8, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 6, TestCondition = "Transient" },
        new TyreTestMetadata { RunNumber = 9, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 6, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { RunNumber = 9, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 6, TestCondition = "10,14 psi" },
        new TyreTestMetadata { RunNumber = 10, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 6, TestCondition = "8 psi" },
        new TyreTestMetadata { RunNumber = 10, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 6, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { RunNumber = 10, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 6, TestCondition = "Speed test" },
        // Row 4: Rim 10, Hoosier 43070 16x6.0-10 R25B, Width 7
        new TyreTestMetadata { RunNumber = 11, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { RunNumber = 12, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { RunNumber = 12, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { RunNumber = 13, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { RunNumber = 13, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { RunNumber = 13, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 7, TestCondition = "Speed test" },
        // Row 5: Rim 10, Hoosier 43075 16x7.5-10 LCO, Width 8
        new TyreTestMetadata { RunNumber = 14, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 8, TestCondition = "Transient" },
        new TyreTestMetadata { RunNumber = 15, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 8, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { RunNumber = 15, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 8, TestCondition = "10,14 psi" },
        new TyreTestMetadata { RunNumber = 16, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 8, TestCondition = "8 psi" },
        new TyreTestMetadata { RunNumber = 16, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 8, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { RunNumber = 16, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 8, TestCondition = "Speed test" },
        // Row 6: Rim 10, Hoosier 43075 16x7.5-10 LCO, Width 7
        new TyreTestMetadata { RunNumber = 17, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { RunNumber = 18, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { RunNumber = 18, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { RunNumber = 19, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { RunNumber = 19, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { RunNumber = 19, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 7, TestCondition = "Speed test" },
        // Row 7: Rim 10, Hoosier 43070 16x6.0-10 LCO, Width 6
        new TyreTestMetadata { RunNumber = 20, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 6, TestCondition = "Transient" },
        new TyreTestMetadata { RunNumber = 21, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 6, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { RunNumber = 21, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 6, TestCondition = "10,14 psi" },
        new TyreTestMetadata { RunNumber = 22, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 6, TestCondition = "8 psi" },
        new TyreTestMetadata { RunNumber = 22, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 6, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { RunNumber = 22, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 6, TestCondition = "Speed test" },
        // Row 8: Rim 10, Hoosier 43070 16x6.0-10 LCO, Width 7
        new TyreTestMetadata { RunNumber = 23, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { RunNumber = 24, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { RunNumber = 24, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { RunNumber = 25, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { RunNumber = 25, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { RunNumber = 25, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 7, TestCondition = "Speed test" },
        // Row 9: Rim 13, Continental 20x7-13 43329, Width 7.8
        new TyreTestMetadata { RunNumber = 35, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "20x7-13 43329", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { RunNumber = 36, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "20x7-13 43329", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { RunNumber = 36, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "20x7-13 43329", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { RunNumber = 37, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "20x7-13 43329", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { RunNumber = 37, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "20x7-13 43329", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { RunNumber = 37, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "20x7-13 43329", RimWidth = 7, TestCondition = "Speed test" },
        // Row 10: Rim 13, Goodyear 20x7-13 D2704, Width 7 (*Tire mounted backwards)
        new TyreTestMetadata { RunNumber = 30, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "Transient (Backwards)" },
        new TyreTestMetadata { RunNumber = 31, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "Initial 12 psi (Backwards)" },
        new TyreTestMetadata { RunNumber = 46, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { RunNumber = 31, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "10,14 psi (Backwards)" },
        new TyreTestMetadata { RunNumber = 46, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { RunNumber = 32, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "8 psi (Backwards)" },
        new TyreTestMetadata { RunNumber = 32, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "Final 12 psi (Backwards)" },
        new TyreTestMetadata { RunNumber = 32, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "Speed test (Backwards)" },
        // Row 11: Rim 13, Goodyear 20x7-13 D2704, Width 8
        new TyreTestMetadata { RunNumber = 41, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "Transient" },
        new TyreTestMetadata { RunNumber = 42, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { RunNumber = 42, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "10,14 psi" },
        new TyreTestMetadata { RunNumber = 44, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "8 psi" },
        new TyreTestMetadata { RunNumber = 44, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { RunNumber = 44, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "Speed test" },
    };

    /// <summary>
    /// Gets test metadata for a given run number
    /// </summary>
    /// <param name="runNumber">The run number extracted from the filename (e.g., 1 from B1965raw1.dat)</param>
    /// <returns>All metadata entries for this run number</returns>
    public static IEnumerable<TyreTestMetadata> GetTestMetadata(int runNumber)
    {
        return TestMappings.Where(m => m.RunNumber == runNumber);
    }

    /// <summary>
    /// Extracts the run number from a filename like "B1965raw1.dat"
    /// </summary>
    /// <param name="filename">The filename to parse</param>
    /// <returns>The run number, or -1 if parsing fails</returns>
    public static int ExtractRunNumber(string filename)
    {
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
        var match = System.Text.RegularExpressions.Regex.Match(fileNameWithoutExtension, @"raw(\d+)");
        return match.Success ? int.Parse(match.Groups[1].Value) : -1;
    }
}
