using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day08_Registers
{
    class Program
    {
        static void Main(string[] args)
        {
            const string REGISTER_PATTERN =
                @"(?<Register>[a-z]+) (?<Change>inc|dec) (?<Value>-?\d+) if (?<ConditionRegister>[a-z]+) (?<ConditionEvaluator>==|!=|<|<=|>|>=) (?<ConditionValue>-?\d+)";

            var instructions = File.ReadAllLines(@"Resources\Input.txt").Select(i => Regex.Match(i, REGISTER_PATTERN));
            var registerList = instructions.Select(i => new Register() { Name = i.Groups["Register"].Value, Value = 0 }).DistinctBy(r => r.Name).ToList();
            var largestValueEver = 0;

            foreach (var instruction in instructions)
            {
                var register = registerList.Find(r => r.Name == instruction.Groups["Register"].Value);
                var conditionRegister = registerList.Find(r => r.Name == instruction.Groups["ConditionRegister"].Value);

                var conditionEvaluator = instruction.Groups["ConditionEvaluator"].Value;
                var conditionValue = int.Parse(instruction.Groups["ConditionValue"].Value);

                if ((conditionEvaluator == "==" && conditionRegister.Value == conditionValue)
                    || (conditionEvaluator == "!=" && conditionRegister.Value != conditionValue)
                    || (conditionEvaluator == "<" && conditionRegister.Value < conditionValue)
                    || (conditionEvaluator == "<=" && conditionRegister.Value <= conditionValue)
                    || (conditionEvaluator == ">" && conditionRegister.Value > conditionValue)
                    || (conditionEvaluator == ">=" && conditionRegister.Value >= conditionValue))
                {
                    if (instruction.Groups["Change"].Value == "inc")
                    {
                        register.Value += int.Parse(instruction.Groups["Value"].Value);
                    }
                    else
                    {
                        register.Value -= int.Parse(instruction.Groups["Value"].Value);
                    }
                }

                if (register.Value > largestValueEver)
                {
                    largestValueEver = register.Value;
                }
            }

            Console.WriteLine(registerList.Max(r => r.Value));
            Console.WriteLine(largestValueEver);
            Console.ReadKey();
        }
    }
}
