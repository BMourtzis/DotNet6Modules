using DotNet6Modules.Modules.Weather;

namespace DotNet6Modules
{
    public interface IModule
    {
        IServiceCollection RegisterModule(IServiceCollection services);
        IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
    }

    public static class ModuleExtensions
    {
        static readonly List<IModule> registeredModules = new List<IModule>();

        public static IServiceCollection RegisterModules(this IServiceCollection services)
        {
            var modules = GetModules();
            foreach(var module in modules)
            {
                module.RegisterModule(services);
                registeredModules.Add(module);
            }

            return services;
        }

        public static WebApplication MapEndpoints(this WebApplication app)
        {
            foreach(var modules in registeredModules)
            {
                modules.MapEndpoints(app);
            }

            return app;
        }

        //Manually create the list of Modules you want to register
        private static IEnumerable<IModule> GetModules()
        {
            
            return new List<Type>()
            {
                typeof(WeatherModule)
            }
            .Select(Activator.CreateInstance)
            .Cast<IModule>();

            //return DiscoverModules();
        }

        //Discover all types that implement IModule
        private static IEnumerable<IModule> DiscoverModules()
        {
            return typeof(IModule).Assembly
                .GetTypes()
                .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
                .Select(Activator.CreateInstance)
                .Cast<IModule>();
        }
    }
}
