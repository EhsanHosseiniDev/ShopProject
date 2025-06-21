using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Test;

public class ProductQueryTests : IClassFixture<StartupFixture>
{
    private readonly IMediator _mediator;

    public ProductQueryTests(StartupFixture fixture)
    {
        _mediator = fixture.ServiceProvider.GetRequiredService<IMediator>();
    }

    [Theory]
    [InlineData(1, 8)]
    [InlineData(7, 2)]
    public async Task WeHave50Product_GetCorrectPageBySize(int page, int size)
    {

        var command = new GetProductsQuery(page, size);

        var result = await _mediator.Send(command);

        Assert.Equal(size, result.PageSize);
    }
}
