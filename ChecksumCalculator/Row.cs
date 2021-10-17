using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ChecksumCalculator
{
    public class Row
    {
        public List<int> Cells { get; }
        public int Max { get; set; }
        public int Min { get; set; }
        public int Difference { get; set; }
        public int Dividend { get; set; }
        public int Divisor { get; set; }
        public int Quotient { get; set; }

        public Row(int[] row)
        {
            Cells = row.ToList();
            Max = Cells.Max();
            Min = Cells.Min();
            Difference = Max - Min;
            Quotient = FindEvenlyDivisibleValues();
        }

        public int FindEvenlyDivisibleValues()
        {
            for (var i = 0; i < Cells.Count; i++)
            {
                for (var j = 0; j < Cells.Count; j++)
                {
                    if (i == j) continue;
                    if (Cells[i] % Cells[j] == 0)
                    {
                        Dividend = Cells[i];
                        Divisor = Cells[j];

                        goto Return;
                    }

                    if (Cells[j] % Cells[i] == 0)
                    {
                        Dividend = Cells[j];
                        Divisor = Cells[i];

                        goto Return;
                    }
                }
            }

            Return:
                return Dividend / Divisor;
        }
    }
}
