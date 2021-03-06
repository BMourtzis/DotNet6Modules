using DotNet6Modules.Modules.Weather.Endpoints;
using DotNet6Modules.Modules.Weather.Services;

namespace DotNet6Modules.Modules.Weather
{
    public class WeatherModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/weather", GetWeather.Get);

            return endpoints;
        }
    }
}
