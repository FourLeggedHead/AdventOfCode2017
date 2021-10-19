using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07_RecursiveCircus
{
    public class ProgramNode
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public List<ProgramNode> Children { get; set; }
        public ProgramNode Parent { get; set; }
        public int Level { get; set; }
        public int TotalWeight { get { return Weight + Children.Sum(c => c.TotalWeight); } }

        public ProgramNode()
        {
            Children = new List<ProgramNode>();
        }
    }
}
