namespace Ordering.Application.Orders.EventHandlers.Domain;
public class OrderCreatedEventHandler
    (
    ILogger<OrderCreatedEventHandler> logger
    )
    : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Order {OrderId} is successfully created.", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
