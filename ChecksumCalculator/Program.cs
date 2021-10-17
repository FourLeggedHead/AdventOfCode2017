using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ChecksumCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var spreadsheet = new Spreadsheet("Resources//Input.txt");
            spreadsheet.CalculateChecksum();
            Console.WriteLine(spreadsheet.CheckSum);
            Console.WriteLine(spreadsheet.ComplexChecksum);
            Console.ReadKey();
        }
    }
}
