using DotNet6Modules.Modules.Weather.Models;
using DotNet6Modules.Modules.Weather.Services;
using Microsoft.AspNetCore.Authorization;

namespace DotNet6Modules.Modules.Weather.Endpoints
{
    public class GetWeather
    {
        [Authorize]
        public static IEnumerable<IWeatherForecast> Get(IWeatherForecastService weatherForecastService)
        {
            return weatherForecastService.ForecastNextDays(5);
        }

    }
}
