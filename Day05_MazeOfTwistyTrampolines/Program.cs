using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day05_MazeOfTwistyTrampolines
{
    class Program
    {
        static void Main(string[] args)
        {
            var jumpOffssets = File.ReadAllLines(@"Resources\Input.txt").Select(int.Parse).ToList();

            var position = 0;
            var nextPosition = 0;
            var steps = 0;

            while (nextPosition < jumpOffssets.Count)
            {
                nextPosition = position + jumpOffssets[position];

                // Part I
                //jumpOffssets[position]++;

                // Part II
                if (jumpOffssets[position] >= 3)
                {
                    jumpOffssets[position]--;
                }
                else
                {
                    jumpOffssets[position]++;
                }

                position = nextPosition;
                steps++;
            }

            Console.WriteLine(steps);

            Console.ReadKey();
        }
    }
}
