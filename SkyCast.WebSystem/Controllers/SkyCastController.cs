using Microsoft.AspNetCore.Mvc;
using SkyCast.WebSystem.Services;

namespace SkyCast.WebSystem.Controllers;

public class SkyCastController : Controller
{

    private readonly WeatherService _weatherService = new WeatherService();



    #region--SkyCast--
    public IActionResult SkyCastIndex()
    {
        return View();
    }
    #endregion

    #region--SkyCast Get Method--

    [HttpGet]
    public async Task<IActionResult> GetWeatherJson(string city)
    {
        var cityy = city?.Trim(); // Remove leading and trailing whitespace


        if (string.IsNullOrEmpty(cityy))
        {
            return Json(new { error = "City name is required." });
        }

        var weather = await _weatherService.GetWeatherAsync(cityy);

        if (weather == null)
        {
            return Json(new { error = "Could not retrieve weather data." });
        }

        return Json(weather);
    }



    #endregion



}
