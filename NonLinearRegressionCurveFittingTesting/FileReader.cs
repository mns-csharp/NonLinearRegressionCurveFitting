using System;
using System.Collections.Generic;
using System.IO;


public static class FileReader
{
    public static List<double> ReadOneColumn(string filePath)
    {
        var data = new List<double>();
        foreach (var line in File.ReadAllLines(filePath))
        {
            if (double.TryParse(line, out double value))
            {
                data.Add(value);
            }
        }
        return data;
    }

    public static (List<double>, List<double>) ReadTwoColumns(string dirPath, string fileName)
    {
        var filePath = Path.Combine(dirPath, fileName);
        var column1 = new List<double>();
        var column2 = new List<double>();

        try
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue; // Skip blank lines
                }

                var split = line.Split(new[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (split.Length < 2)
                {
                    continue;
                }

                if (split.Length > 0 && double.TryParse(split[0], out double firstValue))
                {
                    column1.Add(firstValue);
                }

                if (split.Length > 1 && double.TryParse(split[1], out double secondValue))
                {
                    column2.Add(secondValue);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
        }

        return (column1, column2);
    }
}
