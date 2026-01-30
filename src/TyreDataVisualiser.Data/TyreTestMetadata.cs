namespace TyreDataVisualiser.Data;

/// <summary>
/// Represents metadata for a specific tyre test run
/// Each run tests a specific tire/rim configuration under a specific condition
/// </summary>
public class TyreTestMetadata
{
    public int Round { get; set; } // 6 or 8
    public int RunNumber { get; set; }
    public int RimDiameter { get; set; }
    public string TyreBrand { get; set; } = string.Empty;
    public string TyreModel { get; set; } = string.Empty;
    public double RimWidth { get; set; }
    public string TestCondition { get; set; } = string.Empty; // Transient, Initial 12 psi, 10,14 psi, 8 psi, Final 12 psi, Speed test, Warmup
}

/// <summary>
/// Service to map run numbers from filenames to test metadata
/// Hardcoded mapping based on the provided test configuration
/// </summary>
public class TyreTestMappingService
{
    private static readonly List<TyreTestMetadata> TestMappings = new()
    {
        // ===== ROUND 6 TESTING (B1654) =====
        // Free-Rolling (Cornering) Tests - Runs 1-33
        // Row 1: Rim 13, Hoosier 20.5x6.0 13 R25B A2500 (Item 43127), Width 6
        new TyreTestMetadata { Round = 6, RunNumber = 1, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 6, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 6, RunNumber = 2, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 6, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 2, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 6, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 3, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 6, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 3, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 6, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 3, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 6, TestCondition = "Speed test" },
        // Row 2: Rim 13, Hoosier 20.5x6.0 13 R25B A2500 (Item 43127), Width 7
        new TyreTestMetadata { Round = 6, RunNumber = 2, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 6, RunNumber = 3, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 3, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 4, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 4, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 4, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 7, TestCondition = "Speed test" },
        // Row 3: Rim 13, Hoosier 20.5x7.0 13 R25B A2500 (Item 43128), Width 6
        new TyreTestMetadata { Round = 6, RunNumber = 3, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 6, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 6, RunNumber = 5, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 6, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 5, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 6, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 5, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 6, TestCondition = "8 psi" },
        // Row 4: Rim 13, Hoosier 20.5x7.0 13 R25B A2500 (Item 43128), Width 7
        new TyreTestMetadata { Round = 6, RunNumber = 4, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 6, RunNumber = 7, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 7, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 7, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 7, TestCondition = "8 psi" },
        // Row 5: Rim 13, Hoosier 20.5x7.0 13 R25B A2500 (Item 43153), Width 8
        new TyreTestMetadata { Round = 6, RunNumber = 5, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43153)", RimWidth = 8, TestCondition = "Transient" },
        // Row 6: Rim 13, Continental 205/510R13 (4914), Width 7
        new TyreTestMetadata { Round = 6, RunNumber = 14, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 6, RunNumber = 15, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 15, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 16, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 16, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 16, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 7, TestCondition = "Speed test" },
        // Row 7: Rim 13, Continental 205/510R13 (4914), Width 8
        new TyreTestMetadata { Round = 6, RunNumber = 17, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 8, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 6, RunNumber = 18, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 8, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 18, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 8, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 19, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 8, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 19, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 8, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 19, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 8, TestCondition = "Speed test" },
        // Row 8: Rim 10, Hoosier 18.0x7.5 10 R25B (Item 43105), Width 7
        new TyreTestMetadata { Round = 6, RunNumber = 20, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 6, RunNumber = 21, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 22, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 22, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 22, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 22, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 7, TestCondition = "Speed test" },
        // Row 9: Rim 10, Hoosier 18.0x7.5 10 R25B (Item 43105), Width 8
        new TyreTestMetadata { Round = 6, RunNumber = 23, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 8, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 6, RunNumber = 24, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 8, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 24, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 8, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 25, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 8, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 25, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 8, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 25, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 8, TestCondition = "Speed test" },
        // Row 10: Rim 10, Hoosier 18.0x6.0 10 R25B (Item 43101), Width 6
        new TyreTestMetadata { Round = 6, RunNumber = 28, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x6.0 10 R25B (43101)", RimWidth = 6, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 6, RunNumber = 29, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x6.0 10 R25B (43101)", RimWidth = 6, TestCondition = "Initial 12 psi" },
        // Row 11: Rim 10, Hoosier 18.0x6.0 10 R25B (Item 43101), Width 7
        new TyreTestMetadata { Round = 6, RunNumber = 30, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x6.0 10 R25B (43101)", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 6, RunNumber = 31, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x6.0 10 R25B (43101)", RimWidth = 7, TestCondition = "Initial 12 psi" },
        // Row 12: Rim 10, Hoosier 6.0/18.0 10 LCO C2000 (Item 41100), Width 7
        new TyreTestMetadata { Round = 6, RunNumber = 32, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "6.0/18.0 10 LCO C2000 (41100)", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 6, RunNumber = 33, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "6.0/18.0 10 LCO C2000 (41100)", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 33, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "6.0/18.0 10 LCO C2000 (41100)", RimWidth = 7, TestCondition = "Speed test" },

        // Drive/Brake/Combined Tests - Runs 34-67
        // Row 1: Rim 13, Hoosier 20.5x6.0 13 R25B A2500 (Item 43127), Width 6
        new TyreTestMetadata { Round = 6, RunNumber = 48, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 6, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 6, RunNumber = 49, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 6, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 50, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 6, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 50, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 6, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 50, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 6, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 50, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 6, TestCondition = "Speed test" },
        // Row 2: Rim 13, Hoosier 20.5x6.0 13 R25B A2500 (Item 43127), Width 7
        new TyreTestMetadata { Round = 6, RunNumber = 51, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 7, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 6, RunNumber = 52, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 52, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 53, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 53, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 53, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x6.0 13 R25B A2500 (43127)", RimWidth = 7, TestCondition = "Speed test" },
        // Row 3: Rim 13, Hoosier 20.5x7.0 13 R25B A2500 (Item 43128), Width 6
        new TyreTestMetadata { Round = 6, RunNumber = 54, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 6, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 6, RunNumber = 55, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 6, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 55, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 6, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 56, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 6, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 56, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 6, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 56, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 6, TestCondition = "Speed test" },
        // Row 4: Rim 13, Hoosier 20.5x7.0 13 R25B A2500 (Item 43128), Width 7
        new TyreTestMetadata { Round = 6, RunNumber = 57, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 7, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 6, RunNumber = 58, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 58, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 59, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 59, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 59, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43128)", RimWidth = 7, TestCondition = "Speed test" },
        // Row 5: Rim 13, Hoosier 20.5x7.0 13 R25B A2500 (Item 43153), Width 8
        new TyreTestMetadata { Round = 6, RunNumber = 60, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43153)", RimWidth = 8, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 6, RunNumber = 61, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43153)", RimWidth = 8, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 61, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43153)", RimWidth = 8, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 62, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43153)", RimWidth = 8, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 62, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43153)", RimWidth = 8, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 62, RimDiameter = 13, TyreBrand = "Hoosier", TyreModel = "20.5x7.0 13 R25B A2500 (43153)", RimWidth = 8, TestCondition = "Speed test" },
        // Row 6: Rim 13, Continental 205/510R13 (4914), Width 7
        new TyreTestMetadata { Round = 6, RunNumber = 63, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 7, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 6, RunNumber = 64, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 64, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 65, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 65, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 65, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 7, TestCondition = "Speed test" },
        // Row 7: Rim 13, Continental 205/510R13 (4914), Width 8
        new TyreTestMetadata { Round = 6, RunNumber = 34, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 8, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 6, RunNumber = 35, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 8, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 35, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 8, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 36, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 8, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 36, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 8, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 36, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/510R13 (4914)", RimWidth = 8, TestCondition = "Speed test" },
        // Row 8: Rim 10, Hoosier 18.0x7.5 10 R25B (Item 43105), Width 7
        new TyreTestMetadata { Round = 6, RunNumber = 37, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 7, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 6, RunNumber = 38, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 38, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 39, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 39, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 6, RunNumber = 39, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 7, TestCondition = "Speed test" },
        // Row 9: Rim 10, Hoosier 18.0x7.5 10 R25B (Item 43105), Width 8
        new TyreTestMetadata { Round = 6, RunNumber = 40, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 8, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 6, RunNumber = 41, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x7.5 10 R25B (43105)", RimWidth = 8, TestCondition = "Initial 12 psi" },
        // Row 10: Rim 10, Hoosier 18.0x6.0 10 R25B (Item 43101), Width 6
        new TyreTestMetadata { Round = 6, RunNumber = 42, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x6.0 10 R25B (43101)", RimWidth = 6, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 6, RunNumber = 43, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x6.0 10 R25B (43101)", RimWidth = 6, TestCondition = "Initial 12 psi" },
        // Row 11: Rim 10, Hoosier 18.0x6.0 10 R25B (Item 43101), Width 7
        new TyreTestMetadata { Round = 6, RunNumber = 44, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x6.0 10 R25B (43101)", RimWidth = 7, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 6, RunNumber = 45, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "18.0x6.0 10 R25B (43101)", RimWidth = 7, TestCondition = "Initial 12 psi" },
        // Row 12: Rim 10, Hoosier 6.0/18.0 10 LCO C2000 (Item 41100), Width 7
        new TyreTestMetadata { Round = 6, RunNumber = 46, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "6.0/18.0 10 LCO C2000 (41100)", RimWidth = 7, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 6, RunNumber = 47, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "6.0/18.0 10 LCO C2000 (41100)", RimWidth = 7, TestCondition = "Initial 12 psi" },

        // ===== ROUND 8 TESTING (B1965) =====
        // Free-Rolling (Cornering) Tests - Runs 1-44
        // Row 1: Rim 10, Hoosier 43075 16x7.5-10 R25B, Width 7
        new TyreTestMetadata { Round = 8, RunNumber = 1, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 8, RunNumber = 2, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 2, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 4, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 4, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 4, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 7, TestCondition = "Speed test" },
        // Row 2: Rim 10, Hoosier 43075 16x7.5-10 R25B, Width 8
        new TyreTestMetadata { Round = 8, RunNumber = 5, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 8, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 8, RunNumber = 6, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 8, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 6, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 8, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 7, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 8, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 7, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 8, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 7, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 R25B", RimWidth = 8, TestCondition = "Speed test" },
        // Row 3: Rim 10, Hoosier 43070 16x6.0-10 R25B, Width 6
        new TyreTestMetadata { Round = 8, RunNumber = 8, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 6, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 8, RunNumber = 9, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 6, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 9, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 6, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 10, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 6, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 10, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 6, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 10, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 6, TestCondition = "Speed test" },
        // Row 4: Rim 10, Hoosier 43070 16x6.0-10 R25B, Width 7
        new TyreTestMetadata { Round = 8, RunNumber = 11, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 8, RunNumber = 12, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 12, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 13, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 13, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 13, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 R25B", RimWidth = 7, TestCondition = "Speed test" },
        // Row 5: Rim 10, Hoosier 43075 16x7.5-10 LCO, Width 8
        new TyreTestMetadata { Round = 8, RunNumber = 14, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 8, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 8, RunNumber = 15, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 8, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 15, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 8, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 16, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 8, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 16, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 8, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 16, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 8, TestCondition = "Speed test" },
        // Row 6: Rim 10, Hoosier 43075 16x7.5-10 LCO, Width 7
        new TyreTestMetadata { Round = 8, RunNumber = 17, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 8, RunNumber = 18, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 18, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 19, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 19, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 19, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43075 16x7.5-10 LCO", RimWidth = 7, TestCondition = "Speed test" },
        // Row 7: Rim 10, Hoosier 43070 16x6.0-10 LCO, Width 6
        new TyreTestMetadata { Round = 8, RunNumber = 20, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 6, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 8, RunNumber = 21, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 6, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 21, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 6, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 22, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 6, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 22, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 6, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 22, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 6, TestCondition = "Speed test" },
        // Row 8: Rim 10, Hoosier 43070 16x6.0-10 LCO, Width 7
        new TyreTestMetadata { Round = 8, RunNumber = 23, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 8, RunNumber = 24, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 24, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 25, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 25, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 25, RimDiameter = 10, TyreBrand = "Hoosier", TyreModel = "43070 16x6.0-10 LCO", RimWidth = 7, TestCondition = "Speed test" },
        // Row 9: Rim 13, Continental 20x7-13 43329, Width 7.8
        new TyreTestMetadata { Round = 8, RunNumber = 35, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "20x7-13 43329", RimWidth = 7, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 8, RunNumber = 36, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "20x7-13 43329", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 36, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "20x7-13 43329", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 37, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "20x7-13 43329", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 37, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "20x7-13 43329", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 37, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "20x7-13 43329", RimWidth = 7, TestCondition = "Speed test" },
        // Row 10: Rim 13, Goodyear 20x7-13 D2704, Width 7 (*Tire mounted backwards)
        new TyreTestMetadata { Round = 8, RunNumber = 30, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "Transient (Backwards)" },
        new TyreTestMetadata { Round = 8, RunNumber = 31, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "Initial 12 psi (Backwards)" },
        new TyreTestMetadata { Round = 8, RunNumber = 46, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 31, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "10,14 psi (Backwards)" },
        new TyreTestMetadata { Round = 8, RunNumber = 46, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 32, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "8 psi (Backwards)" },
        new TyreTestMetadata { Round = 8, RunNumber = 32, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "Final 12 psi (Backwards)" },
        new TyreTestMetadata { Round = 8, RunNumber = 32, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "Speed test (Backwards)" },
        // Row 11: Rim 13, Goodyear 20x7-13 D2704, Width 8
        new TyreTestMetadata { Round = 8, RunNumber = 41, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "Transient" },
        new TyreTestMetadata { Round = 8, RunNumber = 42, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 42, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 44, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 44, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 44, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "Speed test" },
        
        // Drive/Brake/Combined Tests (Runs 47-58)
        // Row 1: Rim 13, Continental 205/470R13 43329, Width 7
        new TyreTestMetadata { Round = 8, RunNumber = 47, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/470R13 43329", RimWidth = 7, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 8, RunNumber = 48, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/470R13 43329", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 48, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/470R13 43329", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 49, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/470R13 43329", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 49, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/470R13 43329", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 49, RimDiameter = 13, TyreBrand = "Continental", TyreModel = "205/470R13 43329", RimWidth = 7, TestCondition = "Speed test" },
        // Row 2: Rim 13, Goodyear 20x7-13 D2704, Width 7
        new TyreTestMetadata { Round = 8, RunNumber = 51, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 8, RunNumber = 52, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 52, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 53, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 53, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 53, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 7, TestCondition = "Speed test" },
        // Row 3: Rim 13, Goodyear 20x7-13 D2704, Width 8
        new TyreTestMetadata { Round = 8, RunNumber = 56, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "Warmup" },
        new TyreTestMetadata { Round = 8, RunNumber = 57, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "Initial 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 57, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "10,14 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 58, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "8 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 58, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "Final 12 psi" },
        new TyreTestMetadata { Round = 8, RunNumber = 58, RimDiameter = 13, TyreBrand = "Goodyear", TyreModel = "20x7-13 D2704", RimWidth = 8, TestCondition = "Speed test" },
    };

    /// <summary>
    /// Extracts the round prefix and run number from a filename like "B1965raw1.dat" or "B1654raw33.dat"
    /// </summary>
    /// <param name="filename">The filename to parse</param>
    /// <returns>A tuple of (round, runNumber). Returns (0, -1) if parsing fails</returns>
    public static (int Round, int RunNumber) ExtractRoundAndRunNumber(string filename)
    {
        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
        
        // Extract the round prefix (B1654 or B1965)
        var roundMatch = System.Text.RegularExpressions.Regex.Match(fileNameWithoutExtension, @"^B(1654|1965)");
        int round = 0;
        if (roundMatch.Success)
        {
            round = roundMatch.Groups[1].Value == "1654" ? 6 : 8;
        }
        
        // Extract the run number
        var runMatch = System.Text.RegularExpressions.Regex.Match(fileNameWithoutExtension, @"raw(\d+)");
        int runNumber = runMatch.Success ? int.Parse(runMatch.Groups[1].Value) : -1;
        
        return (round, runNumber);
    }

    /// <summary>
    /// Gets test metadata for a given round and run number
    /// </summary>
    /// <param name="round">The round number (6 or 8)</param>
    /// <param name="runNumber">The run number extracted from the filename</param>
    /// <returns>All metadata entries for this round and run number</returns>
    public static IEnumerable<TyreTestMetadata> GetTestMetadata(int round, int runNumber)
    {
        return TestMappings.Where(m => m.Round == round && m.RunNumber == runNumber);
    }
}
