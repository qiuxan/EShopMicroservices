using BuildingBlocks.CQRS;

namespace Ordering.Application.Orders.Commands.CreateOrder;
public class CreateOrderHandler : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // Create order entity from command obj
        // Save order entity to database
        // Return result
        throw new NotImplementedException();
    }
}

