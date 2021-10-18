using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InverseCaptcha.Main
{
    public class InverseCaptchaNext
    {
        public string DigitsSequence { get; set; }
        public int Sum { get; set; }

        public InverseCaptchaNext()
        {
            DigitsSequence = null;
            Sum = 0;
        }

        private string WriteMatchSequence()
        {
            var matchSequence = new StringBuilder();

            var step = 1;

            for (int i = 0; i < DigitsSequence.Length; i++)
            {
                if (DigitsSequence[i].Equals(DigitsSequence[(i + step) % DigitsSequence.Length]))
                {
                    matchSequence.Append(DigitsSequence[i]);
                }
            }

            return matchSequence.ToString();
        }

        public void Process()
        {
            var matchSequence = WriteMatchSequence();

            Sum = 0;

            foreach (var digit in matchSequence)
            {
                Sum += int.Parse(digit.ToString());
            }
        }
    }
}
