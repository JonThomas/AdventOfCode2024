using System;
using System.IO;

public class Day02
{
    public static int Solve()
    {
        var input = File.ReadAllText("Day02Input.txt");
        var lines = input.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);

        var numberOfSafeReports = 0;

        foreach (var line in lines)
        {
            var levels = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);
            if(CheckIfReportIsSafe(line, levels))
                numberOfSafeReports++;
        }

        return numberOfSafeReports;
    }

    private static bool CheckIfReportIsSafe(string line, string[] levels)
    {
        var previousLevel = -1;
        bool? increasing = null;

        foreach (var levelText in levels)
        {
            if (!int.TryParse(levelText, out int level))
            {
                throw new Exception("Line contains invalid level: " + line);
            }

            if (previousLevel == -1)
            {
                previousLevel = level;
                continue;
            }

            if (level > previousLevel && level - previousLevel <= 3 && (increasing == null || increasing == true))
            {
                increasing = true;
                previousLevel = level;
            }
            else if (level < previousLevel && previousLevel - level <= 3 && (increasing == null || increasing == false))
            {
                previousLevel = level;
                increasing = false;
            }
            else
            {
                Console.WriteLine("Line is not safe: " + line);
                return false;
            }
        }

        return true;
    }
}