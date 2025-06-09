using System;
using System.IO;
using System.Runtime.CompilerServices;

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
                continue;
            }

            // Have to account for one problem dampener. Test by removing the the level 
            // at the levelIndex, and the two levels before
            for (var i = levelIndexOrSuccess - 2; i < levelIndexOrSuccess + 1; i++)
            {
                if (i < 0 || i > levels.Count) // Makes sure we don't go out of bounds
                {
                    continue;
                } 

                if (CheckIfReportIsOkWithoutThisLevel(levels, i))
                {
                    // Found a safe report by removing one level
                    Console.WriteLine($"Line is safe after removing level {levels[i]} at position {i} from: " + string.Join(" ", levels));
                    numberOfSafeReports++;
                    break;
                }

                if(i == levelIndexOrSuccess + 1)
                {
                    Console.WriteLine($"Line is not safe, even after testing for problem dampeners: " + line);
                }
            }
        }

        return numberOfSafeReports;
    }

    private static bool CheckIfReportIsOkWithoutThisLevel(List<string> levels, int i)
    {
        var shorterReport = new List<string>(levels);
        shorterReport.RemoveAt(i);
        if (CheckIfReportIsSafe(shorterReport) == -1)
        {
            // Found a safe report by removing one level
            return true;
        }

        return false;
    }

    public static int CheckIfReportIsSafe(List<string> levels)
    {
        var previousLevel = -1;
        bool? increasing = null;
        int i = 0;

        foreach (var levelText in levels)
        {
            if (!int.TryParse(levelText, out int level))
            {
                throw new Exception("Line contains invalid level: " + string.Join(" ", levels));
            }

            if (previousLevel == -1)
            {
                previousLevel = level;
                i++;
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
            i++;
        }

        return -1;  // Level is safe, return -1 to indicate success
    }
}