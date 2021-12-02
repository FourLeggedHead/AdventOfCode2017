using System;
using System.IO;
using System.Linq;

namespace Day_13___Packet_Scanners
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 13: Packet Scanners");

            var layers = File.ReadAllLines(@".\Resources\input.txt").Select(l => l.Split(':').Select(int.Parse))
                .ToDictionary(l => l.ElementAt(0), l => l.ElementAt(1));

            // Part I
            var severity = layers.Select(l => l.Key % ((l.Value - 1) * 2) == 0 ? l.Key * l.Value : 0).Sum();
            Console.WriteLine(severity);

            // Part II
            var delay = 0;
            var caughtCount = 0;

            do
            {
                delay++;
                caughtCount = layers.Select(l => (l.Key + delay) % ((l.Value - 1) * 2) == 0 ? 1 : 0).Sum();

            } while (caughtCount != 0);

            Console.WriteLine(delay);
        }
    }
}
