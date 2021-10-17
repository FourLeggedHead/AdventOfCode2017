using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMemory.Main
{
    public class Square
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }

        public Square()
        {
            
        }

        public Square(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
        }
    }
}
