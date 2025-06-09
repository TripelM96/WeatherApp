using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;
using System.Security.Principal;
using System.Text.Json.Serialization;
using WeatherApp.Services.Models;

namespace WeatherApp.Services
{
    public class WeatherStackService : IWeatherService
    {
        private string _baseUrl = "http://api.weatherstack.com";
        private string _accessKey = "84ccaf2674ba01762ce570cf2154b761";

        public WeatherData GetWeather(string region)
        {
            var endpoint = $"/current?access_key={_accessKey}&query={region}";

            //using var client = new RestClientOptions(_baseUrl);

            using var client = new RestClient(_baseUrl);
            var request = new RestRequest(endpoint, method: Method.Get);

          

            var response = client.Execute<WeatherStackCurrentRoot>(request);
            var data = response.Data;

            return new WeatherData()
            {
                Region = data.Request.Query,
                Country = data.Location.Country,
                Lat = data.Location.Lat,
                Lon = data.Location.Lon,
                Temperature = data.Current.Temperature,
                IconUrl = data.Current.WeatherIcons?[0] ?? "#"
 
            };

        }
    }
}

public class WeatherStackCurrentRoot
{
    public WeatherStackRequest Request { get; set; }
    public WeatherStackLocation Location { get; set; }
    public WeatherStackCurrent Current { get; set; }

}

public class WeatherStackCurrent
{
    public int Temperature { get; set; }

    [JsonPropertyName("weather_icons")]
    public string[] WeatherIcons { get; set; }

}



public class WeatherStackRequest
{
    public string Type { get; set; }
    public string Query { get; set; }
    public string Language { get; set; }
    public string Unit { get; set; }
}

public class WeatherStackLocation
{
    public string Country { get; set; }
    public string Lat { get; set; }
    public string Lon { get; set; }
}