using WeatherApp.Services;
using WeatherApp.Services.Models;

namespace WeatherApp.Services
{
    public class WeatherRandomService : IWeatherService
    {
        public WeatherData GetWeather(string region)
        {
            return new WeatherData()
            {
                Country = "Portugual",
                //Region = region,
                IconUrl = "https://cdn.worldweatheronline.com/images/wsymbols01_png_64/wsymbol_0001_sunny.png",
                Lat = Random.Shared.NextDouble().ToString(),
                Lon = Random.Shared.NextDouble().ToString(),
                Temperature = Random.Shared.Next(0, 45)
            };
        }
    }
}

