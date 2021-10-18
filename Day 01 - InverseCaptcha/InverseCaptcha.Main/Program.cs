using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InverseCaptcha.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var streamReader = new StreamReader("Resources//inputnext.txt");
            var inverseCaptchaNext = new InverseCaptchaNext();
            inverseCaptchaNext.DigitsSequence = streamReader.ReadLine();
            inverseCaptchaNext.Process();
            Console.WriteLine(inverseCaptchaNext.Sum.ToString());
            streamReader.Close();

            streamReader = new StreamReader("Resources//inputhalfway.txt");
            var inverseCaptchaHalfway = new InverseCaptchaHalfway();
            inverseCaptchaHalfway.DigitsSequence = streamReader.ReadLine();
            inverseCaptchaHalfway.Process();
            Console.WriteLine(inverseCaptchaHalfway.Sum.ToString());
            streamReader.Close();

            Console.ReadKey();
        }
    }
}