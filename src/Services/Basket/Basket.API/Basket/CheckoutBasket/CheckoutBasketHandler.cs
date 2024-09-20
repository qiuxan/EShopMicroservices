using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Basket.API.Basket.CheckoutBasket;
public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto)
    :ICommand<CheckoutBasketResult>;
public record CheckoutBasketResult(bool IsSuccess);

public class CheckoutBasketCommandValitator
    : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutBasketCommandValitator()
    {
        RuleFor(x => x.BasketCheckoutDto).NotNull().WithMessage("BasketCheckout Dto can not be null");
        RuleFor(x => x.BasketCheckoutDto.UserName).NotNull().WithMessage("UserName can not be null");
    }
}
public class CheckoutCommandBasketHandler
    (IBasketRepository basketRepository, IPublishEndpoint publishEndpoint)
    :ICommandHandler<CheckoutBasketCommand, CheckoutBasketResult>
{
    public async Task<CheckoutBasketResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        //get existing basket with total price
        var basket = await basketRepository.GetBasket(command.BasketCheckoutDto.UserName,cancellationToken);
        if(basket == null)
        {
           return new CheckoutBasketResult(false);
        }

        var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();

        //set total price on basketcheckout event message

        eventMessage.TotalPrice = basket.TotalPrice;

        //send basketcheckout eveent to rabbitmq using masstransit

        await publishEndpoint.Publish(eventMessage,cancellationToken);
        //delete basket
        await basketRepository.DeleteBasket(command.BasketCheckoutDto.UserName,cancellationToken);

        return new CheckoutBasketResult(true);
    }
}
