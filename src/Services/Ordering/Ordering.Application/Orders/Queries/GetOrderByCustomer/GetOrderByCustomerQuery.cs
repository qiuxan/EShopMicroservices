namespace Ordering.Application.Orders.Queries.GetOrderByCustomer;
public record GetOrderByCustomerQuery(Guid CumstomerId)
    : IQuery<GetOrderByCustomerResult>;
public record GetOrderByCustomerResult(IEnumerable<OrderDto> Orders);