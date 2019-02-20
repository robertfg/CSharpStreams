using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CodeChallenges
{
    class Challenge2
    {
        static void Main(string[] args)
        {
            // Character digression
            char capitalH = 'H';
            char lowerH = '\u0068';
            Console.WriteLine(capitalH + " " + lowerH);

            byte[] unicodeBytes = UnicodeEncoding.Unicode.GetBytes(new char[] { lowerH });
            Console.WriteLine(unicodeBytes);

            string unicodeString = UnicodeEncoding.Unicode.GetString(unicodeBytes);
            Console.WriteLine(unicodeString);

            sbyte signedByte = -128;

            char degree = '\u00B0';

            Console.WriteLine("The temperature is 76.2" + degree + "F.");

            byte[] mysteryMessage = { 89, 0, 97, 0, 121, 0, 33, 0 };
            string messageContents = UnicodeEncoding.Unicode.GetString(mysteryMessage);

            Console.WriteLine(mysteryMessage + " " + messageContents);

            Console.ReadLine();
        }
    }
}
