using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Command.Carts.Commands;
using Shop.Application.Utiles;
using Shop.Domain.Aggregators.Carts;
using Shop.Domain.Aggregators.Orders;
using Shop.Domain.Aggregators.Products;

namespace Shop.Application;

public static class DependencyConfigurations
{
    public static void AddShopServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddValidatorsFromAssemblyContaining<AddProductToCartValidator>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddRepositories();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, InMemoryProductRepository>();
        services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
        services.AddSingleton<ICartRepository, InMemoryCartRepository>();
    }
}
