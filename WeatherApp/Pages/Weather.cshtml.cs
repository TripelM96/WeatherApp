using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using WeatherApp.Services;
using WeatherApp.Services.Models;


namespace WeatherApp.Pages
{
    public class WeatherModel : PageModel
    {
        private readonly IWeatherService _weatherService;

        public WeatherModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public WeatherData Weather { get; set; }

        public void OnGet(string region)
        {
            region ??= "Leiria";
           this.Weather = _weatherService.GetWeather(region);
        }
    }
}
    