using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SkyCast.Models.DTOs;


public class WeatherResponse
{
    [JsonProperty("name")]
    public string Name { get; set; } // City Name

    [JsonProperty("main")]
    public MainWeather Main { get; set; } // Main weather data

    [JsonProperty("weather")]
    public List<WeatherDescription> Weather { get; set; } // Weather description list

    [JsonProperty("wind")]
    public Wind Wind { get; set; } // Wind data

    [JsonProperty("sys")]
    public Sys Sys { get; set; } // Country and Sunrise/Sunset
}

public class MainWeather
{
    [JsonProperty("temp")]
    public float Temp { get; set; }

    [JsonProperty("feels_like")]
    public float FeelsLike { get; set; }

    [JsonProperty("humidity")]
    public int Humidity { get; set; }
}

public class WeatherDescription
{
    [JsonProperty("main")]
    public string Main { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("icon")]
    public string Icon { get; set; }
}

public class Wind
{
    [JsonProperty("speed")]
    public float Speed { get; set; }

    [JsonProperty("deg")]
    public int Degree { get; set; }
}

public class Sys
{
    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("sunrise")]
    public long Sunrise { get; set; }

    [JsonProperty("sunset")]
    public long Sunset { get; set; }
}