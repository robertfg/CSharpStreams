using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Working with streams
using System.IO;

namespace SoccerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDir = Directory.GetCurrentDirectory();
            DirectoryInfo dir = new DirectoryInfo(currentDir);

            Console.WriteLine(currentDir);

            //var files = dir.GetFiles();

            // Use a pattern
            var files = dir.GetFiles("*.txt");
            foreach (var fil in files)
            {
                Console.WriteLine(fil.Name);
            }

            // Read the contents of a file:
            var fileName = Path.Combine(dir.FullName, "data.txt");
            var file = new FileInfo(fileName);
            
            if ( file.Exists )
            {
                /*var reader = new StreamReader(file.FullName);
                try
                {
                    Console.SetIn(reader);
                    Console.WriteLine( Console.ReadLine() );
                }
                finally
                {
                    reader.Close();
                }*/

                // Better way:
                using (var reader = new StreamReader(file.FullName))
                {
                    Console.SetIn(reader);
                    Console.WriteLine(Console.ReadLine());
                }
            }

            Console.ReadKey();
        }
    }
}
