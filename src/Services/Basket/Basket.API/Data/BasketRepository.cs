
namespace Basket.API.Data;

public class BasketRepository : IBasketRepository
{
    public Task<bool> DeleteBasketAsync(string userName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
