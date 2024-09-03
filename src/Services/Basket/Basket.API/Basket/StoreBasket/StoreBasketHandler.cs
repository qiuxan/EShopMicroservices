

namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart):ICommand<StoreBasketResult>;
public record StoreBasketResult(string UserName);

public class StoreBasketCommandValidator:AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName can not be empty");
    }
}

public class StoreBasketCommandHandler
    (
        IBasketRepository repository
    )
    : ICommandHandler<StoreBasketCommand,StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        //TODO: communicate with Discount.Grpc, and calculate latest prices of product into shopping cart

        await repository.StoreBasket(command.Cart,cancellationToken);

        return new StoreBasketResult(command.Cart.UserName);
    }
}

