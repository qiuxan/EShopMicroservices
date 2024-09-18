
using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.Queries.GetordersByName;
public class GetordersByNameHandler
    (
        IApplicationDbContext dbContext
    )
    : IQueryHandler<GetordersByNameQuery, GetordersByNameResult>
{
    public async Task<GetordersByNameResult> Handle(GetordersByNameQuery query, CancellationToken cancellationToken)
    {
        var orders = await dbContext.Orders
                     .Include(o => o.OrderItems)
                     .AsNoTracking()
                     .Where(o => o.OrderName.Value.Contains(query.Name))
                     .OrderBy(o => o.OrderName.Value)
                     .ToListAsync(cancellationToken);

        return new GetordersByNameResult(orders.ToOrderDtos());
    }

}
