using System;
using System.IO;

public class Day02Part2
{
    public static int Solve()
    {
        var input = File.ReadAllText("Day02Input.txt");
        var lines = input.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);

        var numberOfSafeReports = 0;

        foreach (var line in lines)
        {
            List<string> levels = line.Split([' '], StringSplitOptions.RemoveEmptyEntries).ToList();
            var levelIndexOrSuccess = CheckIfReportIsSafe(levels);
            if (levelIndexOrSuccess == -1)
            {
                // Success: report is safe without removing any levels
                Console.WriteLine("Line is safe, no problem dampeners: " + line);
                numberOfSafeReports++;
            }
            else
            {
                // Have to account for one problem dampener. Test by removing the level before, at and after this levelIndex
                for (var i = -1; i < 2; i++)
                {
                    levelIndexOrSuccess = CheckIfReportIsSafe(levels!.RemoveAt(i));
                    if (levelIndexOrSuccess == -1)
                    {
                        // Found a safe report by removing one level
                        Console.WriteLine($"Line is safe after removing level {i} from: " + line);
                        numberOfSafeReports++;
                        break;
                    }
                }
            }
        }

        return numberOfSafeReports;
    }

    private static int CheckIfReportIsSafe(List<string> levels)
    {
        var previousLevel = -1;
        bool? increasing = null;
        int i = 0;

        foreach (var levelText in levels)
        {
            i++;
            if (!int.TryParse(levelText, out int level))
            {
                throw new Exception("Line contains invalid level: " + string.Join(" ", levels));   
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
                return i;   // Problem detected, return the index of the level that caused the issue
            }
        }

        return -1;  // Level is safe, return -1 to indicate success
    }
}