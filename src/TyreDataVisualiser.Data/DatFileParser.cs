using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace TyreDataVisualiser.Data;

/// <summary>
/// Parses tire telemetry .dat files and extracts metadata and data points
/// </summary>
public class DatFileParser
{
    /// <summary>
    /// Represents the header information parsed from a .dat file
    /// </summary>
    public class DatFileHeader
    {
        public string ProjectId { get; set; } = string.Empty;
        public int RunNumber { get; set; }
        public DateTime TestDate { get; set; }
        public TimeSpan TestTime { get; set; }
        public bool IsoMode { get; set; }
        public string DataFileId { get; set; } = string.Empty;
    }

    /// <summary>
    /// Parses a .dat file and extracts the metadata and telemetry data
    /// </summary>
    /// <param name="fileContent">The full content of the .dat file as a string</param>
    /// <returns>A tuple containing the parsed header and list of data points</returns>
    public static (DatFileHeader Header, List<TelemetryDataPoint> DataPoints) ParseDatFile(string fileContent)
    {
        var lines = fileContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        
        if (lines.Length < 4)
            throw new InvalidOperationException("Invalid .dat file format: insufficient lines");

        // Parse header (line 1)
        var header = ParseHeader(lines[0]);

        // Parse column headers (line 2)
        var columnHeaders = lines[1].Split('\t');

        // Line 3 is units - we'll use it to validate but don't need to store
        // var units = lines[2].Split('\t');

        // Parse data points (lines 4+)
        var dataPoints = new List<TelemetryDataPoint>();
        for (int i = 3; i < lines.Length; i++)
        {
            var line = lines[i].Trim();
            if (string.IsNullOrEmpty(line))
                continue;

            try
            {
                var dataPoint = ParseDataLine(line, columnHeaders);
                dataPoints.Add(dataPoint);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error parsing data line {i + 1}: {ex.Message}", ex);
            }
        }

        return (header, dataPoints);
    }

    /// <summary>
    /// Parses the first line of the .dat file containing metadata
    /// Example: "TIRF Data File: Project 1965; Run 005; Date 07-30-2018; Time 17:56; ISO False; ID wBxy9c3"
    /// </summary>
    private static DatFileHeader ParseHeader(string headerLine)
    {
        var header = new DatFileHeader();

        try
        {
            // Split by semicolon to get individual fields
            var fields = headerLine.Split(';');

            foreach (var field in fields)
            {
                var trimmedField = field.Trim();

                if (trimmedField.Contains("Project"))
                {
                    // Extract project number: "Project 1965" -> "1965"
                    var parts = trimmedField.Split(' ');
                    if (parts.Length >= 2)
                        header.ProjectId = parts[1];
                }
                else if (trimmedField.Contains("Run"))
                {
                    // Extract run number: "Run 005" -> 5
                    var parts = trimmedField.Split(' ');
                    if (parts.Length >= 2 && int.TryParse(parts[1], out var runNum))
                        header.RunNumber = runNum;
                }
                else if (trimmedField.Contains("Date"))
                {
                    // Extract date: "Date 07-30-2018" -> DateTime
                    var parts = trimmedField.Split(' ');
                    if (parts.Length >= 2 && DateTime.TryParseExact(parts[1], "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                        header.TestDate = date;
                }
                else if (trimmedField.Contains("Time"))
                {
                    // Extract time: "Time 17:56" -> TimeSpan
                    var parts = trimmedField.Split(' ');
                    if (parts.Length >= 2 && TimeSpan.TryParseExact(parts[1], "hh\\:mm", CultureInfo.InvariantCulture, out var time))
                        header.TestTime = time;
                }
                else if (trimmedField.Contains("ISO"))
                {
                    // Extract ISO mode: "ISO False" -> bool
                    var parts = trimmedField.Split(' ');
                    if (parts.Length >= 2 && bool.TryParse(parts[1], out var isoMode))
                        header.IsoMode = isoMode;
                }
                else if (trimmedField.Contains("ID"))
                {
                    // Extract ID: "ID wBxy9c3" -> "wBxy9c3"
                    var parts = trimmedField.Split(' ');
                    if (parts.Length >= 2)
                        header.DataFileId = parts[1];
                }
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error parsing .dat file header: {ex.Message}", ex);
        }

        return header;
    }

    /// <summary>
    /// Parses a single data line and maps values to their corresponding columns
    /// </summary>
    private static TelemetryDataPoint ParseDataLine(string line, string[] columnHeaders)
    {
        var values = line.Split('\t');

        if (values.Length != columnHeaders.Length)
            throw new InvalidOperationException($"Column count mismatch: expected {columnHeaders.Length}, got {values.Length}");

        var dataPoint = new TelemetryDataPoint();

        // Create a mapping of column headers to indices
        var headerMap = columnHeaders
            .Select((header, index) => (header.Trim(), index))
            .ToDictionary(x => x.Item1, x => x.index);

        // Parse each column based on the header
        foreach (var (header, index) in headerMap)
        {
            if (index >= values.Length)
                continue;

            var valueStr = values[index].Trim();
            if (string.IsNullOrEmpty(valueStr))
                continue;

            if (!double.TryParse(valueStr, NumberStyles.Float, CultureInfo.InvariantCulture, out var value))
                continue;

            // Map header to property using a dictionary for cleaner code
            switch (header)
            {
                case "ET": dataPoint.ET = value; break;
                case "V": dataPoint.V = value; break;
                case "N": dataPoint.N = value; break;
                case "SA": dataPoint.SA = value; break;
                case "IA": dataPoint.IA = value; break;
                case "RL": dataPoint.RL = value; break;
                case "RE": dataPoint.RE = value; break;
                case "P": dataPoint.P = value; break;
                case "FX": dataPoint.FX = value; break;
                case "FY": dataPoint.FY = value; break;
                case "FZ": dataPoint.FZ = value; break;
                case "MX": dataPoint.MX = value; break;
                case "MZ": dataPoint.MZ = value; break;
                case "NFX": dataPoint.NFX = value; break;
                case "NFY": dataPoint.NFY = value; break;
                case "RST": dataPoint.RST = value; break;
                case "TSTI": dataPoint.TSTI = value; break;
                case "TSTC": dataPoint.TSTC = value; break;
                case "TSTO": dataPoint.TSTO = value; break;
                case "AmbTmp": dataPoint.AmbTmp = value; break;
                case "SR": dataPoint.SR = value; break;
            }
        }

        return dataPoint;
    }
}
