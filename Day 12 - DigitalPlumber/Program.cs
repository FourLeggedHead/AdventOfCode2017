using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day12_DigitalPlumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var streamReader = new StreamReader(@"Resources\Input.txt");
            var village = new List<ProgramCitizen>();

            while (!streamReader.EndOfStream)
            {
                var programCard = streamReader.ReadLine();
                var matches = Regex.Matches(programCard, "\\d+");

                var citizenId = int.Parse(matches[0].Value);
                var newProgramCitizen = village.Find(c => c.ID == citizenId);
                if (newProgramCitizen == null)
                {
                    newProgramCitizen = new ProgramCitizen {ID = citizenId};
                    village.Add(newProgramCitizen);
                }

                for (int i = 1; i < matches.Count; i++)
                {
                    var pipeId = int.Parse(matches[i].Value);
                    if (pipeId == citizenId) continue;
                    var connectedCitizen = village.Find(c => c.ID == pipeId);
                    if (connectedCitizen == null)
                    {
                        connectedCitizen = new ProgramCitizen { ID = pipeId };
                        village.Add(connectedCitizen);
                    }

                    if (!newProgramCitizen.PipesTo.Contains(connectedCitizen))
                    {
                        newProgramCitizen.PipesTo.Add(connectedCitizen);
                    }

                    if (!connectedCitizen.PipesTo.Contains(newProgramCitizen))
                    {
                        connectedCitizen.PipesTo.Add(newProgramCitizen);
                    }
                }
            }

            village = village.OrderBy(c => c.ID).ToList();

            List<ProgramCitizen> connectedProgram = new List<ProgramCitizen>();
            village.Find(c => c.ID == 0).GetConnected(connectedProgram);

            Console.WriteLine(connectedProgram.Count);

            var groupsCount = 0;
            var citizen = village.Find(c => c.GroupId == -1);
            while (citizen != null)
            {
                var rootId = citizen.ID;
                citizen.AssignGroup(rootId);
                groupsCount++;

                citizen = village.Find(c => c.GroupId == -1);
            }

            Console.WriteLine(groupsCount);
            Console.ReadKey();

            streamReader.Close();
        }
    }

    class ProgramCitizen
    {
        public int ID { get; set; }
        public List<ProgramCitizen> PipesTo { get; set; }
        public int GroupId { get; set; }

        public ProgramCitizen()
        {
            PipesTo = new List<ProgramCitizen>();
            GroupId = -1;
        }

        public void GetConnected(List<ProgramCitizen> connectedPrograms)
        {
            if (connectedPrograms.Count == 0)
            {
                connectedPrograms.Add(this);
            }

            foreach (var pipe in PipesTo)
            {
                if (connectedPrograms.Contains(pipe)) continue;
                connectedPrograms.Add(pipe);
                pipe.GetConnected(connectedPrograms);
            }
        }

        public void AssignGroup(int rootId)
        {
            if (GroupId == -1)
            {
                GroupId = rootId;

                foreach (var pipe in PipesTo)
                {
                    if (pipe != null)
                    {
                        pipe.AssignGroup(rootId);
                    }
                }
            }
        }
    }
}
