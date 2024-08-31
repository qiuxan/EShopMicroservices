

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

public class StoreBasketCommandHandler:ICommandHandler<StoreBasketCommand,StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        
        ShoppingCart cart = command.Cart;

        //to do: save basket to db use marten upsert if exists update else insert

        //update cache

        return new StoreBasketResult("john doe");
    }
}

