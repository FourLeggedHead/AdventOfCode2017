using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMemory.Main
{
    public class ComplexSpiralMemory
    {
        public List<Square> Squares { get; set; }

        public ComplexSpiralMemory()
        {
            Squares = new List<Square>
            {
                new Square(0, 0, 1),
                new Square(1, 0, 1)

            };
        }

        public void FindFirstSquareWithValueGreaterThan(int inputValue)
        {
            var memorySquareId = 1;
            var lastSquare = Squares.Last();

            while (lastSquare.Value <= inputValue)
            {
                var nextSquare = new Square
                {
                    X = lastSquare.X,
                    Y = lastSquare.Y
                };

                // Calculate coordinate of next square

                if (nextSquare.X == memorySquareId - 1 && nextSquare.Y == 1 - memorySquareId)
                {
                    nextSquare.X = memorySquareId;
                }
                else if (nextSquare.X == memorySquareId && nextSquare.Y < memorySquareId)
                {
                    nextSquare.Y++;
                }
                else if (nextSquare.X > -memorySquareId && nextSquare.Y == memorySquareId)
                {
                    nextSquare.X--;
                }
                else if (nextSquare.X == -memorySquareId && nextSquare.Y > -memorySquareId)
                {
                    nextSquare.Y--;
                }
                else if (nextSquare.X < memorySquareId && nextSquare.Y == -memorySquareId)
                {
                    nextSquare.X++;
                }

                // Calculate next square value

                Square firstAdjacentSquare = null;
                Square secondAdjacentSquare = null;
                Square thirdAdjacentSquare = null;
                Square fourthAdjacentSquare = null;

                if (nextSquare.X == memorySquareId && nextSquare.Y <= memorySquareId && nextSquare.Y > -memorySquareId)
                {
                    firstAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X - 1 && square.Y == nextSquare.Y -1);
                    secondAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X - 1 && square.Y == nextSquare.Y);
                    thirdAdjacentSquare = 
                        Squares.FirstOrDefault(square => square.X == nextSquare.X - 1 && square.Y == nextSquare.Y + 1);
                    fourthAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X && square.Y == nextSquare.Y - 1);
                }
                else if (nextSquare.X >= -memorySquareId && nextSquare.X < memorySquareId && nextSquare.Y == memorySquareId)
                {
                    firstAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X + 1 && square.Y == nextSquare.Y - 1);
                    secondAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X && square.Y == nextSquare.Y - 1);
                    thirdAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X - 1 && square.Y == nextSquare.Y - 1);
                    fourthAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X + 1 && square.Y == nextSquare.Y);
                }
                else if (nextSquare.X == -memorySquareId && nextSquare.Y >= -memorySquareId && nextSquare.Y < memorySquareId)
                {
                    firstAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X + 1 && square.Y == nextSquare.Y + 1);
                    secondAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X + 1 && square.Y == nextSquare.Y);
                    thirdAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X + 1 && square.Y == nextSquare.Y - 1);
                    fourthAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X && square.Y == nextSquare.Y + 1);
                }
                else if (nextSquare.X <= memorySquareId && nextSquare.X > -memorySquareId && nextSquare.Y == -memorySquareId)
                {
                    firstAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X - 1 && square.Y == nextSquare.Y + 1);
                    secondAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X && square.Y == nextSquare.Y + 1);
                    thirdAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X + 1 && square.Y == nextSquare.Y + 1);
                    fourthAdjacentSquare =
                        Squares.FirstOrDefault(square => square.X == nextSquare.X - 1 && square.Y == nextSquare.Y);
                }

                nextSquare.Value = (firstAdjacentSquare?.Value ?? 0) + (secondAdjacentSquare?.Value ?? 0) +
                    (thirdAdjacentSquare?.Value ?? 0) + (fourthAdjacentSquare?.Value ?? 0);

                Squares.Add(nextSquare);

                if (nextSquare.X == memorySquareId && nextSquare.Y == -memorySquareId)
                {
                    memorySquareId++;
                }

                lastSquare = nextSquare;
            }
        }
    }
}
