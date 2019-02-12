using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CodeChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(System.IO.Directory.GetCurrentDirectory());

            string fileName = Path.Combine(directory.FullName, "secretmessage.txt");

            using (var reader = new StreamReader(fileName))
            {
                Console.SetIn(reader);
                Console.WriteLine(Console.ReadLine());
            }
        }
    }
}
