using System;
using System.IO;

public class Day1
{
    public static int Solve()
    {
        var input = File.ReadAllText("Day1Input.txt");
        var lines = input.Split(['\n','\r'], StringSplitOptions.RemoveEmptyEntries);

        var list1 = new List<int>();
        var list2 = new List<int>();
        var totalDifference = 0;
 
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

        list1.Sort();
        list2.Sort();

        for (int i = 0; i < list1.Count; i++)
        {
            Console.WriteLine($"First: {list1[i]}, Second: {list2[i]}");
            totalDifference += Math.Abs(list1[i] - list2[i]);
        }

        return totalDifference;
    }
}