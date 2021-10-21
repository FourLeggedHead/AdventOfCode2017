using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09_StreamProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            var streamReader = new StreamReader(@"Resources\Input.txt");

            var scoreLevel = 0;
            var totalScore = 0;
            var inGarbage = false;
            var garbageCharactersCount = 0;

            
            while (!streamReader.EndOfStream)
            {
                var nextChar = streamReader.Read();
                if (inGarbage)
                {
                    if (nextChar == '>')
                    {
                        inGarbage = false;
                    }
                    else if(nextChar == '!')
                    {
                        streamReader.Read();
                    }
                    else
                    {
                        garbageCharactersCount++;
                    }
                }
                else
                {
                    if (nextChar == '{')
                    {
                        scoreLevel++;
                    }
                    else if (nextChar == '}')
                    {
                        totalScore += scoreLevel;
                        scoreLevel--;
                    }
                    else if (nextChar == '<')
                    {
                        inGarbage = true;
                    }
                }
            }

            streamReader.Close();

            Console.WriteLine(totalScore + " " + garbageCharactersCount);
            Console.ReadKey();
        }
    }
}
