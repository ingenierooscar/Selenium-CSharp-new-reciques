using SolidToken.SpecFlow.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using EaApplicationTest.Pages;
using EaFramework.Config;
using EaFramework.Driver;

namespace EeSpectFlowTests
{
    public class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            services
                .AddSingleton(ConfigReader.ReadConfig())
                .AddScoped<IDriverFixture, DriverFixture>()
                .AddScoped<IDriverWait, DriverWait>()
                .AddScoped<IHomePage, HomePage>()
                .AddScoped<IProductPage, ProductPage>();

            return services;
        }
    }
}
