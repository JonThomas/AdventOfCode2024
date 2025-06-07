using System;
using System.IO;

public class Day02
{
    public static int Solve()
    {
        var input = File.ReadAllText("Day01Input.txt");
        var lines = input.Split(['\n','\r'], StringSplitOptions.RemoveEmptyEntries);

        var list1 = new List<int>();
        var list2 = new List<int>();
        var similarityScore = 0;
 
        foreach (var line in lines)
        {
            var twoNumber = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);
            if (twoNumber.Length != 2)
            {
                throw new Exception("Line does not contain exactly two numbers: " + line);
            }

            if (int.TryParse(twoNumber[0], out int first) && int.TryParse(twoNumber[1], out int second))
            {
                list1.Add(first);
                list2.Add(second);
            }
            else
            {
                throw new Exception("Line does not contain valid integers: " + line);
            }

        }

        for (int i = 0; i < list1.Count; i++)
        {
            var numberOfTimes = list2.Count(x => x == list1[i]);
            Console.WriteLine($"First: {list1[i]}, NumberOfTimes: {numberOfTimes}");

            similarityScore += list1[i] * numberOfTimes;
        }

        return similarityScore;
    }
}