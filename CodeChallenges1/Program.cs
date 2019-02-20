using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Treehouse.CodeChallenges
{
    public class Program
    {
        public static void Main(string[] arg)
        {
        }

        public static WeatherForecast ParseWeatherForecast(string[] values)
        {
            WeatherForecast weatherForecast = new WeatherForecast();
            weatherForecast.WeatherStationId = values[0];

            DateTime timeOfDay;
            if (DateTime.TryParse(values[1], out timeOfDay))
            {
                weatherForecast.TimeOfDay = timeOfDay;
            }

            Condition condition;
            if (Enum.TryParse(values[2], out condition))
            {
                weatherForecast.Condition = condition;
            }

            int parseInt;
            if (int.TryParse(values[3], out parseInt))
            {
                weatherForecast.Temperature = parseInt;
            }

            double dblParse;
            if (double.TryParse(values[4], out dblParse))
            {
                weatherForecast.PrecipitationChance = dblParse;
            }
            if (double.TryParse(values[5], out dblParse))
            {
                weatherForecast.PrecipitationAmount = dblParse;
            }

            return weatherForecast;
        }

        public static List<WeatherForecast> DeserializeWeather(string fileName)
        {
            var weatherForecasts = new List<WeatherForecast>();

            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                weatherForecasts = serializer.Deserialize<List<WeatherForecast>>(jsonReader);
            }

            return weatherForecasts;
        }

        public static void SerializeWeatherForecasts(List<WeatherForecast> weatherForecasts, string fileName)
        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, weatherForecasts);
            }
        }
    }
}
