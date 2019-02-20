﻿using System;
using Newtonsoft.Json;

/* Sample CSV Data 

weather_station_id,time_of_day,condition,temperature,precipitation_chance,precipitation_amount
HGKL8Q,06/11/2016 0:00,Rain,53,0.3,0.03
HGKL8Q,06/11/2016 6:00,Cloudy,56,0.08,0.01
HGKL8Q,06/11/2016 12:00,PartlyCloudy,70,0,0
HGKL8Q,06/11/2016 18:00,Sunny,76,0,0
HGKL8Q,06/11/2016 19:00,Clear,74,0,0
*/

namespace Treehouse.CodeChallenges
{
    public class WeatherForecast
    {
        [JsonProperty(PropertyName = "weather_station_id")]
        public string WeatherStationId { get; set; }

        [JsonProperty(PropertyName = "time_of_day")]
        public DateTime TimeOfDay { get; set; }

        public Condition Condition { get; set; }
        public int Temperature { get; set; }

        [JsonProperty(PropertyName = "precipitation_chance")]
        public double PrecipitationChance { get; set; }

        [JsonProperty(PropertyName = "precipitation_amount")]
        public double PrecipitationAmount { get; set; }
    }

    public enum Condition
    {
        Rain,
        Cloudy,
        PartlyCloudy,
        PartlySunny,
        Sunny,
        Clear
    }
}
