using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// JSON Deserializer:
using Newtonsoft.Json;
using System.Net;

namespace SoccerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDir = Directory.GetCurrentDirectory();
            DirectoryInfo dir = new DirectoryInfo(currentDir);
            var fileName = Path.Combine(dir.FullName, "SoccerGameResults.csv");

            var fileContents = ReadSoccerResults(fileName);

            /*var fileContents = ReadFile(fileName);

            //Console.WriteLine(fileContents);

            string[] fileLines = fileContents.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in fileLines)
            {
                Console.WriteLine(line);
            }

            Console.ReadKey();*/

            // Read from a file:
            fileName = Path.Combine(dir.FullName, "players.json");
            var players = DeserializePlayers(fileName);

            //foreach (var player in players)
            //{
            //    Console.WriteLine(player.FirstName + " " + player.LastName);
            //}

            //var topTenPlayers = GetTopTenPlayers(players);
            //foreach (var player in topTenPlayers)
            //{
            //    Console.WriteLine("Name: " + player.FirstName + " " + player.LastName + ", PPG: " + player.PointsPerGame);
            //}
            //Console.ReadKey();

            // Write to a file:
            //fileName = Path.Combine(dir.FullName, "topten.json");
            //SerializePlayersToFile(topTenPlayers, fileName);

            Console.WriteLine(GetGoogleHomePage());
            Console.ReadKey();
        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<GameResult> ReadSoccerResults(string fileName)
        //public static List<string[]> ReadSoccerResults(string fileName)
        //public static List<string> ReadSoccerResults(string fileName)
        {
            var soccerResults = new List<GameResult>();
            //var soccerResults = new List<string[]>();
            //var soccerResults = new List<string>();
            using (var reader = new StreamReader(fileName))
            {
                //while (reader.Peek() > -1)
                //{
                //    string[] line = reader.ReadLine().Split(',');
                //    //string line = reader.ReadLine();
                //    soccerResults.Add(line);
                //}

                string line = "";

                // Read 1st line of header information:
                reader.ReadLine();
                
                while ((line = reader.ReadLine()) != null)
                {
                    var gameResult = new GameResult();

                    string[] values = line.Split(',');

                    // 1st value is a date
                    if (DateTime.TryParse(values[0], out DateTime gameDate))
                    {
                        gameResult.GameDate = gameDate;
                    }
                    gameResult.TeamName = values[1];

                    HomeOrAway homeOrAway;
                    if ( Enum.TryParse(values[2], out homeOrAway) )
                    {
                        gameResult.HomeOrAway = homeOrAway;
                    }

                    int parseInt;
                    if (int.TryParse(values[3], out parseInt))
                    {
                        gameResult.Goals = parseInt;
                    }
                    if (int.TryParse(values[4], out parseInt))
                    {
                        gameResult.GoalAttempts= parseInt;
                    }
                    if (int.TryParse(values[5], out parseInt))
                    {
                        gameResult.ShotsOnGoal= parseInt;
                    }
                    if (int.TryParse(values[6], out parseInt))
                    {
                        gameResult.ShotsOffGoal = parseInt;
                    }

                    double possessionPercent;
                    if ( double.TryParse(values[7], out possessionPercent))
                    {
                        gameResult.PossessionPercent = possessionPercent;
                    }

                    // Better to use getter:
                    //gameResult.ConversionRate = (double)gameResult.Goals / gameResult.GoalAttempts;

                    soccerResults.Add(gameResult);
                    //soccerResults.Add(values);
                }
            }
            return soccerResults;
        }

        public static List<Player> DeserializePlayers(string fileName)
        {
            var players = new List<Player>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                players = serializer.Deserialize<List<Player>>(jsonReader);
            }

            return players;
        }

        public static List<Player> GetTopTenPlayers(List<Player> players)
        {
            var topTenPlayers = new List<Player>();
            players.Sort(new PlayerComparer());
            int counter = 0;
            foreach(var player in players)
            {
                topTenPlayers.Add(player);
                counter++;
                if (counter == 10)
                {
                    break;
                }
            }
            return topTenPlayers;
        }

        public static void SerializePlayersToFile(List<Player> players, string fileName)
        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, players);
            }
        }

        public static string GetGoogleHomePage()
        {
            var webClient = new WebClient();
            byte[] googleHome = webClient.DownloadData("https://www.google.com");

            // No good: Stream stream = new Stream();

            // Implicit type declarations:
            using (var stream = new MemoryStream(googleHome))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
