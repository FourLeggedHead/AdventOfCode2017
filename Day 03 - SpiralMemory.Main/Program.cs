using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMemory.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new Input(312051);
            input.CalculatePosition();
            Console.WriteLine(input.Step);

            var complexMemory = new ComplexSpiralMemory();
            complexMemory.FindFirstSquareWithValueGreaterThan(312051);
            Console.WriteLine(complexMemory.Squares.Last().Value);

            Console.ReadKey();
        }
    }
}
