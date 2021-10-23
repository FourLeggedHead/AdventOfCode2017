using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;
using System.Text;
using System.Threading.Tasks;

namespace Day10_KnotHash
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part I
            var list = Enumerable.Range(0,256).ToList();
            var lengthList = File.ReadAllLines(@"Resources\Input.txt")[0].Split(',').Select(int.Parse).ToList();

            var position = 0;
            var skipSize = 0;

            foreach (var length in lengthList)
            {
                var listToReverse = new List<int>();

                for (int i = 0; i < length; i++)
                    listToReverse.Add(list[(position + i) % list.Count]);

                listToReverse.Reverse();

                for (int i = 0; i < length; i++)
                    list[(position + i) % list.Count] = listToReverse[i];

                position += length + skipSize;
                skipSize++;
            }

            Console.WriteLine(list.Take(2).Aggregate((x,y) => x * y));

            // Part II
            list = Enumerable.Range(0, 256).ToList();
            var asciiLengthList = File.ReadAllLines(@"Resources\Input.txt")[0].Select(c => (int)c).ToList();
            asciiLengthList.AddRange(new int[] { 17, 31, 73, 47, 23 });

            position = 0;
            skipSize = 0;

            for (int roundIndex = 0; roundIndex < 64; roundIndex++)
            {
                foreach (var length in asciiLengthList)
                {
                    var listToReverse = new List<int>();

                    for (int i = 0; i < length; i++)
                        listToReverse.Add(list[(position + i) % list.Count]);

                    listToReverse.Reverse();

                    for (int i = 0; i < length; i++)
                        list[(position + i) % list.Count] = listToReverse[i];

                    position += length + skipSize;
                    skipSize++;
                }
            }

            var stringBuilder = new StringBuilder();
            var denseHash = new List<int>(16);
            position = 0;
            for (int i = 0; i < 16; i++)
            {
                var denseHashValue = list[position];
                for (int j = 1; j < 16; j++)
                    denseHashValue ^= list[position + j];
                denseHash.Add(denseHashValue);
                stringBuilder.Append(denseHashValue.ToString("X2"));

                position += 16;
            }

            Console.WriteLine(stringBuilder.ToString().ToLower());
            Console.ReadKey();
        }
    }
}
