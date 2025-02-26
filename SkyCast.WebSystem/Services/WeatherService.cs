using Newtonsoft.Json;
using SkyCast.Models.DTOs;

namespace SkyCast.WebSystem.Services;

public class WeatherService
{

    private readonly string _apiKey = "83d8f1944d3b13adaafff4fb49dbfa5e";
    private readonly string _baseUrl = "https://api.openweathermap.org/data/2.5/weather";

    public async Task<WeatherResponse> GetWeatherAsync(string city)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = $"{_baseUrl}?q={city}&appid={_apiKey}&units=metric"; // Fetching weather in Celsius
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherResponse>(json);
            }
            else
            {
                return null; // Handle error 
            }
        }
    }


}
