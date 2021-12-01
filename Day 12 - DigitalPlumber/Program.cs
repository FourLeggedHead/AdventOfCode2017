using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_12___DigitalPlumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 12: Digital Plumber");

            // Part I
            var regex = new Regex(@"(?<Id>\d+) <-> (?<ToIds>(\d+,? ?)+)");
            var programPipesDictionary = File.ReadAllLines(@"Resources\Input.txt").Select(l => regex.Match(l))
                                    .ToDictionary(k => int.Parse(k.Groups["Id"].Value),
                                            v => v.Groups["ToIds"].Value.Replace(" ", String.Empty).Split(',').Select(int.Parse).ToList());

            var connectedPrograms = new List<int>();
            ListConnectedPrograms(0, programPipesDictionary, connectedPrograms);

            Console.WriteLine(connectedPrograms.Count);

            // Part II
            var programGroupsDictionary = programPipesDictionary.ToDictionary(k => k.Key, v => -1);
            var programsWithoutGroup = programGroupsDictionary.Where(p => p.Value == -1).Select(p => p.Key).OrderBy(p => p).ToArray();
            while (programsWithoutGroup.Count() != 0)
            {
                AssignGroup(programsWithoutGroup[0], programsWithoutGroup[0], programPipesDictionary, programGroupsDictionary);
                programsWithoutGroup = programGroupsDictionary.Where(p => p.Value == -1).Select(p => p.Key).OrderBy(p => p).ToArray();
            }

            Console.WriteLine(programGroupsDictionary.Select(p => p.Value).Distinct().Count());
        }

        static void ListConnectedPrograms(int rootProgram, Dictionary<int, List<int>> programPipesDictionary, List<int> connectedPrograms)
        {
            if (connectedPrograms.Count == 0)
            {
                connectedPrograms.Add(rootProgram);
            }

            foreach (var pipe in programPipesDictionary[rootProgram])
            {
                if (connectedPrograms.Contains(pipe)) continue;
                connectedPrograms.Add(pipe);
                ListConnectedPrograms(pipe, programPipesDictionary, connectedPrograms);
            }
        }

        static void AssignGroup(int rootProgram, int groupId, Dictionary<int, List<int>> programPipesDictionary, Dictionary<int, int> programGroupsDictionary)
        {
            if (programGroupsDictionary[rootProgram] == -1)
            {
                programGroupsDictionary[rootProgram] = groupId;

                foreach (var pipe in programPipesDictionary[rootProgram])
                {
                    AssignGroup(pipe, groupId, programPipesDictionary, programGroupsDictionary);
                }
            }
        }
    }
}
