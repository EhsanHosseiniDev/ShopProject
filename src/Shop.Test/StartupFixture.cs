using Microsoft.Extensions.DependencyInjection;
using Shop.Application;

public class StartupFixture
{
    public IServiceProvider ServiceProvider { get; }

    public StartupFixture()
    {
        var services = new ServiceCollection();
        services.AddShopServices();

        ServiceProvider = services.BuildServiceProvider();
    }
}
