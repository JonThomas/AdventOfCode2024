using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

public class Day03Part1
{
    public static int Solve()
    {
        var input = File.ReadAllText("input/Day03Input.txt");
        //var lines = input.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);

        var pattern = @"mul\((?<number1>\d{1,3}),(?<number2>\d{1,3})\)";

        var regexpMatches = Regex.Matches(input, pattern);

        var total = 0;

        foreach(Match match in regexpMatches)
        {
            var number1 = int.Parse(match.Groups[1].Value);
            var number2 = int.Parse(match.Groups[2].Value);
            Console.WriteLine($"Match: {match}, with numbers {number1} and {number2}");
            total += number1 * number2;
        }

        return total;
    }
        
}