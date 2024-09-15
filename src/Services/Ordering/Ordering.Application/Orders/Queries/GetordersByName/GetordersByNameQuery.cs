namespace Ordering.Application.Orders.Queries.GetordersByName;
public record GetordersByNameQuery(string Name) : IQuery<GetordersByNameResult>;

public record GetordersByNameResult(IEnumerable<OrderDto> Orders);
