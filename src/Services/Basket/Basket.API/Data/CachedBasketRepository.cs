
namespace Basket.API.Data;

public class CachedBasketRepository
    (
        IBasketRepository repository
    )
    : IBasketRepository
{
    public Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        return repository.GetBasket(userName, cancellationToken);
    }

    public Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        return repository.StoreBasket(basket, cancellationToken);
    }

    public Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        return repository.DeleteBasket(userName, cancellationToken);
    }
}
