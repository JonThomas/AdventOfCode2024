using System;
using System.Collections.Generic;
using System.Data;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024
{
    public class Day05Part1
    {
        public static int Solve()
        {
            var input = File.ReadAllText("input/Day05Input.txt");
            List<int> orderedList = ParseAndSortPageOrderingRules(input);

            return 0; // Return the solution as an integer
        }

        private static List<int> ParseAndSortPageOrderingRules(string input)
        {
            var rules = ParseIntoRules(input);

            var pagesInOrder = new List<int>();

            pagesInOrder.Add(rules.First().Before);
            pagesInOrder.Add(rules.First().After);
            rules.RemoveAt(0);

            while(rules.Any())
            {
                for(int i = 0; i < rules.Count; i++)
                {
                    var rule = rules[i];
                    if(pagesInOrder.Contains(rule.Before) && pagesInOrder.Contains(rule.After))
                    {
                        // Both pages are already in the list, skip this rule
                        rules.Remove(rule);
                        Console.WriteLine($"Skipping {rule}, both pages already in order. Pages: {string.Join(",", pagesInOrder)}");
                        break;
                    }
                    if (rule.Before == pagesInOrder.Last())
                    {
                        pagesInOrder.Add(rule.After);
                        rules.Remove(rule);
                        Console.WriteLine($"Added {rule.After} to end. Removed {rule}, {rules.Count} rules to go. Pages: {string.Join(",", pagesInOrder)}");
                        break;
                    }
                    if(rule.After == pagesInOrder.First())
                    {
                        pagesInOrder.Insert(0, rule.Before);
                        rules.Remove(rule);
                        Console.WriteLine($"Added {rule.Before} to start. Removed {rule}, {rules.Count} rules to go. Pages: {string.Join(",", pagesInOrder)}");
                        break;
                    }
                    if(pagesInOrder.Contains(rule.After))
                    {
                        // rule.Before must be before this index.
                        // Check if we have a rule that makes it possible to insert rule.Before just before this index
                        var afterIndex = pagesInOrder.IndexOf(rule.After);
                        var findBefore = pagesInOrder[afterIndex - 1];
                        var foundRule = CheckIfRuleExist(rules, findBefore, rule.Before);
                        if(foundRule != null)
                        {
                            pagesInOrder.Insert(afterIndex, rule.Before);
                            rules.Remove(rule);
                            rules.Remove((Rule)foundRule);
                            Console.WriteLine($"Added {rule.Before} between {findBefore} and {rule.After}. Removed {foundRule} and {rule}, {rules.Count} rules to go. Pages: {string.Join(",", pagesInOrder)}");
                            break;
                        }
                    }
                    if (pagesInOrder.Contains(rule.Before))
                    {
                        // rule.After must be after this index.
                        // Check if we have a rule that makes it possible to insert rule.After just after this index
                        var beforeIndex = pagesInOrder.IndexOf(rule.Before);
                        var findAfter = pagesInOrder[beforeIndex + 1];
                        var foundRule = CheckIfRuleExist(rules, rule.Before, findAfter);
                        if (foundRule != null)
                        {
                            pagesInOrder.Insert(beforeIndex+1, rule.After);
                            rules.Remove(rule);
                            rules.Remove((Rule)foundRule);
                            Console.WriteLine($"Added {rule.After} between {rule.After} and {findAfter}. Removed {foundRule} and {rule}, {rules.Count} rules to go. Pages: {string.Join(",", pagesInOrder)}");
                            break;
                        }
                    }
                }
            }

            return pagesInOrder;
        }

        private static Rule? CheckIfRuleExist(List<Rule> rules, int findBefore, int after)
        {
            foreach (var rule in rules)
            {
                if (rule.Before == findBefore && rule.After == after)
                {
                    return rule;
                }
            }
            return null;
        }

        private static List<Rule> ParseIntoRules(string input)
        {
            var lines = input.Split("\r\n");
            var rules = new List<Rule>();
            foreach (var currentRule in lines)
            {
                if(string.IsNullOrEmpty(currentRule))
                {
                    break;
                }
                var numbers = currentRule.Split('|');
                var rule = new Rule(int.Parse(numbers[0].Trim()), int.Parse(numbers[1].Trim()));
                rules.Add(rule);
            }

            return rules;
        }
    }

    public struct Rule
    {
        public Rule(int before, int after)
        {
            Before = before;
            After = after;
        }

        public int Before { get; }
        public int After { get; }
        public override string ToString() => $"({Before}, {After})";
    }
}
