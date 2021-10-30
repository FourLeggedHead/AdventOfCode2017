using System;
using System.IO;
using System.Linq;

namespace Day11_HexEd
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = File.ReadAllText(@"Resources\Input.txt").TrimEnd('\n').Split(',').ToList();

            var position = new[] {0,0};
            var maxStepsAway = 0;

            foreach (var step in path)
            {
                if (step == "n")
                {
                    position[1] += 2;
                }
                else if (step == "s")
                {
                    position[1] -= 2;
                }
                else if (step == "ne")
                {
                    position[0] += 1;
                    position[1] += 1;
                }
                else if (step == "nw")
                {
                    position[0] -= 1;
                    position[1] += 1;
                }
                else if (step == "se")
                {
                    position[0] += 1;
                    position[1] -= 1;
                }
                else if (step == "sw")
                {
                    position[0] -= 1;
                    position[1] -= 1;
                }

                var stepsAway = Math.Abs(position[0]) + (Math.Abs(position[1]) - Math.Abs(position[0])) / 2;
                maxStepsAway = stepsAway > maxStepsAway ? stepsAway : maxStepsAway;
            }

            var minStep = Math.Abs(position[0]) + (Math.Abs(position[1]) - Math.Abs(position[0])) / 2;

            Console.WriteLine("(" + position[0] + "," + position[1] + ")");
            Console.WriteLine(minStep + " " + maxStepsAway);
            Console.ReadKey();
        }
    }
}
