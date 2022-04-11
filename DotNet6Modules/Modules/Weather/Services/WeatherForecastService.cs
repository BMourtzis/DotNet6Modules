using DotNet6Modules.Modules.Weather.Models;

namespace DotNet6Modules.Modules.Weather.Services
{
    public interface IWeatherForecastService
    {
        public IEnumerable<IWeatherForecast> ForecastNextDays(int days);
    }

    public class WeatherForecastService: IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<IWeatherForecast> ForecastNextDays(int days = 1)
        {
            return Enumerable.Range(1, days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
.ToArray();
        }
    }
}
