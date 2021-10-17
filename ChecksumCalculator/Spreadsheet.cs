using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq.Expressions;

namespace ChecksumCalculator
{
    public class Spreadsheet
    {
        public List<Row> Rows { get; set; }
        public int CheckSum { get; set; }
        public int ComplexChecksum { get; set; }

        public Spreadsheet()
        {
            Rows = new List<Row>();
        }

        public Spreadsheet(string path)
        {
            Rows = new List<Row>();

            var streamReader = new StreamReader(path);

            var line = streamReader.ReadLine();
            while (line != null)
            {
                Rows.Add(new Row(line.Split('\t').Select(int.Parse).ToArray()));

                line = streamReader.ReadLine();
            }

            streamReader.Close();
        }

        public void CalculateChecksum()
        {
            CheckSum = 0;
            ComplexChecksum = 0;

            foreach (var row in Rows)
            {
                CheckSum += row.Difference;
                ComplexChecksum += row.Quotient;
            }
        }
    }
}
