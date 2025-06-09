using WeatherApp.Services.Models;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        WeatherData GetWeather(string region);
    }
}