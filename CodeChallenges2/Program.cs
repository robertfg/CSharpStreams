using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;

namespace CodeChallenges2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetTreehouseHome());
            Console.ReadKey();
        }

        public static string GetTreehouseHome()
        {
            string treehouse = "";
            // Put code here
            using (var webClient = new WebClient())
            {
                byte[] treehouseBytes = webClient.DownloadData("https://www.teamtreehouse.com");

                using (var stream = new MemoryStream(treehouseBytes))
                using (var reader = new StreamReader(stream))
                {
                    treehouse = reader.ReadToEnd();
                }
            }

            return treehouse;
        }
    }
}
