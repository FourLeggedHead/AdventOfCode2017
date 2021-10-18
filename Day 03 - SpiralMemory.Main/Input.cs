using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMemory.Main
{
    public class Input
    {
        public int Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        private int _step;
        public int Step { get => Math.Abs(X) + Math.Abs(Y); set => _step = value; }

        public Input()
        {
            
        }

        public Input(int value)
        {
            Value = value;
        }

        public void CalculatePosition()
        {
            if (Value == 1)
            {
                X = Y = 0;
                return;
            }

            var squareId = 1;
            var firstSquarevalue = 2;
            var firstNextSquareValue = 10;

            while (Value >= firstSquarevalue)
            {
                if (Value < firstNextSquareValue)
                {
                    break;
                }

                squareId++;
                firstSquarevalue = firstNextSquareValue;
                firstNextSquareValue = 2 + 4 * squareId * (squareId + 1);
            }

            var squareValue = firstSquarevalue;
            X = squareId;
            Y = 1 - squareId;

            while (squareValue < Value)
            {
                squareValue++;

                if (X == squareId && Y < squareId)
                {
                    Y++;
                    continue;
                }
                if (X > - squareId && Y == squareId)
                {
                    X--;
                    continue;
                }
                if (X == -squareId && Y > -squareId)
                {
                    Y--;
                    continue;
                }
                if (X < squareId && Y == -squareId)
                {
                    X++;
                }
            }
        }
    }
}
