using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10_KnotHash
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            for (int i = 0; i < 256; i++)
            {
                list.Add(i);
            }

            var streamReader = new StreamReader(@"Resources\TestInput.txt");

            var stringBuilder = new StringBuilder();

            while (!streamReader.EndOfStream)
            {
                stringBuilder.Append((int) streamReader.Read());
                stringBuilder.Append(",");
            }
            stringBuilder.Append("17,31,73,47,23");

            var lengthList = stringBuilder.ToString().Split(',').ToList().Select(int.Parse);
            streamReader.Close();

            var position = 0;
            var skipSize = 0;

            for (int roundIndex = 0; roundIndex < 64; roundIndex++)
            {
                foreach (var length in lengthList)
                {
                    var listToReverse = new List<int>();

                    for (int i = 0; i < length; i++)
                    {
                        listToReverse.Add(list[(position + i) % list.Count]);
                    }

                    listToReverse.Reverse();

                    for (int i = 0; i < length; i++)
                    {
                        list[(position + i) % list.Count] = listToReverse[i];
                    }

                    position += length + skipSize;
                    skipSize++;
                }
            }

            stringBuilder.Clear();

            var denseHash = new List<int>(16);
            position = 0;
            for (int i = 0; i < 16; i++)
            {
                var denseHashValue = list[position];
                for (int j = 1; j < 16; j++)
                {
                    denseHashValue ^= list[position + j];
                }
                denseHash.Add(denseHashValue);
                stringBuilder.Append(denseHashValue.ToString("X2"));

                position += 16;
            }

            Console.WriteLine(stringBuilder.ToString().ToLower());
            Console.ReadKey();
        }
    }
}
