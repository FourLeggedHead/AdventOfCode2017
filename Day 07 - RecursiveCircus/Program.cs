using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day07_RecursiveCircus
{
    class Program
    {
        static void Main(string[] args)
        {
            const string PROGRAM_PATTERN = @"(?<Program>[a-z]+) [(](?<Weight>\d+)[)]( -> (?<SubTowers>([a-z]+),* *)*)?";

            var nodeStrings = File.ReadAllLines(@"Resources\Input.txt");

            var Tree = new List<ProgramNode>();
            foreach (var nodeString in nodeStrings)
            {
                if (!Regex.IsMatch(nodeString, PROGRAM_PATTERN))
                    throw new Exception($"Entry {nodeString} is not valid.");

                var nodeMatch = Regex.Match(nodeString, PROGRAM_PATTERN);

                var node = Tree.Find(n => n.Name == nodeMatch.Groups["Program"].Value);

                if (node == null)
                {
                    node = new ProgramNode
                    {
                        Name = nodeMatch.Groups["Program"].Value,
                        Weight = int.Parse(nodeMatch.Groups["Weight"].Value)
                    }; 

                    Tree.Add(node);
                }
                else
                {
                    node.Weight = int.Parse(nodeMatch.Groups["Weight"].Value);
                }

                if (nodeMatch.Groups["SubTowers"].Length > 0)
                {
                    foreach (Capture subNodeMatch in nodeMatch.Groups["SubTowers"].Captures)
                    {
                        var subNodeName = subNodeMatch.Value.Trim(' ').Trim(',');

                        var subNode = Tree.Find(p => p.Name == subNodeName);
                        if (subNode == null)
                        {
                            subNode = new ProgramNode
                            {
                                Name = subNodeName
                            };

                            Tree.Add(subNode);
                        }
                        subNode.Parent = node;
                        node.Children.Add(subNode);
                    }
                }
            }

            var rootNode = Tree.Find(n => n.Parent == null);

            var level = 1;
            rootNode.Level = level;

            var nodesAtLevel = Tree.FindAll(n => n.Level == level);
            while (nodesAtLevel.Count != 0)
            {
                level++;

                foreach (var node in nodesAtLevel)
                {
                    var weightsList = new List<int>();
                    foreach (var nodeChild in node.Children)
                    {
                        nodeChild.Level = level;
                        weightsList.Add(nodeChild.TotalWeight);
                    }

                    if (weightsList.Count != 0 && weightsList.Max() != weightsList.Min())
                    {
                        var countMax = weightsList.FindAll(p => p == weightsList.Max()).Count;
                        var counMin = weightsList.FindAll(p => p == weightsList.Min()).Count;

                        ProgramNode culprit = null;
                        var correctWeight = 0;

                        if (counMin > countMax)
                        {
                            culprit = node.Children.Find(p => p.TotalWeight == weightsList.Max());
                            correctWeight = culprit.Weight + weightsList.Min() - weightsList.Max();
                        }
                        else
                        {
                            culprit = node.Children.Find(p => p.TotalWeight == weightsList.Min());
                            correctWeight = culprit.Weight + weightsList.Max() - weightsList.Min();
                        }

                        Console.WriteLine($"Correct weigth: {correctWeight}");
                    }
                }

                nodesAtLevel = Tree.FindAll(n => n.Level == level);
            }
            
            Console.WriteLine(rootNode.Name + " " + level);
            Console.ReadKey();
        }
    }
}
