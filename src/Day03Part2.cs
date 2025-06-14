using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

public class Day03Part2
{
    public static int Solve()
    {
        var input = File.ReadAllText("input/Day03Input.txt");
        //var lines = input.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);

        var pattern = @"mul\((?<number1>\d{1,3}),(?<number2>\d{1,3})\)|don't\(\)|do\(\)";

        var regexpMatches = Regex.Matches(input, pattern);

        var total = 0;
        var add = true;

        foreach(Match match in regexpMatches)
        {
            Console.WriteLine($"Match: {match}");
            if (match.Value == "don't()")
            {
                add = false;
            }
            else if (match.Value == "do()")
            {
                add = true;
            }
            else if(add)
            {
                var number1 = int.Parse(match.Groups[1].Value);
                var number2 = int.Parse(match.Groups[2].Value);
                Console.WriteLine($"       {match}, with numbers {number1} and {number2}");
                total += number1 * number2;
            }
            else
            {
                Console.WriteLine($"       {match}, but add = false");
            }
        }

        return total;
    }
        
}