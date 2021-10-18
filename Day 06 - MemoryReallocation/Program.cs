using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06_MemoryReallocation
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankList = File.ReadAllLines(@"Resources\Input.txt")[0].Split('\t').ToList().Select(int.Parse).ToList();

            var Configurations = new List<string>();
            var configuration = WriteConfiguration(bankList);
            int cycleCount = 0;

            while (!Configurations.Contains(configuration))
            {
                Configurations.Add(configuration);

                var blockValue = bankList.First(b => b == bankList.Max());
                var blockIndex = bankList.IndexOf(blockValue);

                bankList[blockIndex] = 0;

                for (int i = 0; i < blockValue; i++)
                {
                    bankList[(blockIndex + i + 1) % bankList.Count]++;
                }

                configuration = WriteConfiguration(bankList);
                cycleCount++;
            }

            var loopSize = Configurations.Count - Configurations.FindIndex(h => h == configuration);

            Console.WriteLine(cycleCount + " " + loopSize);
            Console.ReadKey();
        }

        static string WriteConfiguration(List<int> bankList)
        {
            return string.Join("\t", bankList.Select(b => b.ToString()));
        }
    }
}
