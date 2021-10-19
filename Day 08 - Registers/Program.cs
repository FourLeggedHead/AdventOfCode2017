using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08_Registers
{
    class Program
    {
        static void Main(string[] args)
        {
            var streamReader = new StreamReader(@"Resources\Input.txt");
            var instruction = streamReader.ReadLine();

            var registersList = new List<Register>();
            var largestValueEver = 0;

            while (instruction != null)
            {
                var instructionElements = instruction.Split(' ');

                var targetRegister = registersList.Find(r => r.Name == instructionElements[0]);
                if (targetRegister == null)
                {
                    targetRegister = new Register
                    {
                        Name = instructionElements[0],
                        Value = 0
                    };

                    registersList.Add(targetRegister);
                }

                var conditionRegister = registersList.Find(r => r.Name == instructionElements[4]);
                if (conditionRegister == null)
                {
                    conditionRegister = new Register
                    {
                        Name = instructionElements[4],
                        Value = 0
                    };

                    registersList.Add(conditionRegister);
                }

                if (instructionElements[5] == "==")
                {
                    if (conditionRegister.Value == int.Parse(instructionElements[6]))
                    {
                        ModifyRegister(targetRegister, instructionElements);
                    }
                }
                else if (instructionElements[5] == "!=")
                {
                    if (conditionRegister.Value != int.Parse(instructionElements[6]))
                    {
                        ModifyRegister(targetRegister, instructionElements);
                    }
                }
                else if (instructionElements[5] == ">")
                {
                    if (conditionRegister.Value > int.Parse(instructionElements[6]))
                    {
                        ModifyRegister(targetRegister, instructionElements);
                    }
                }
                else if (instructionElements[5] == "<")
                {
                    if (conditionRegister.Value < int.Parse(instructionElements[6]))
                    {
                        ModifyRegister(targetRegister, instructionElements);
                    }
                }
                else if (instructionElements[5] == ">=")
                {
                    if (conditionRegister.Value >= int.Parse(instructionElements[6]))
                    {
                        ModifyRegister(targetRegister, instructionElements);
                    }
                }
                else if (instructionElements[5] == "<=")
                {
                    if (conditionRegister.Value <= int.Parse(instructionElements[6]))
                    {
                        ModifyRegister(targetRegister, instructionElements);
                    }
                }

                if (targetRegister.Value > largestValueEver)
                {
                    largestValueEver = targetRegister.Value;
                }

                instruction = streamReader.ReadLine();
            }

            var largestValue = 0;
            foreach (var register in registersList)
            {
                if (register.Value > largestValue)
                {
                    largestValue = register.Value;
                }
            }

            Console.WriteLine(largestValue);
            Console.WriteLine(largestValueEver);
            Console.ReadKey();

            streamReader.Close();
        }

        static void ModifyRegister(Register targetRegister, string[] instructionElements)
        {
            if (instructionElements[1].Equals("inc"))
            {
                targetRegister.Value += int.Parse(instructionElements[2]);
            }
            else
            {
                targetRegister.Value -= int.Parse(instructionElements[2]);
            }
        }
    }
}
