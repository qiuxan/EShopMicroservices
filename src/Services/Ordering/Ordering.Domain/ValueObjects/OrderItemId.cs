namespace Ordering.Domain.ValueObjects;
public class OrderItemId
{
    public Guid Value { get; }

    private OrderItemId(Guid value) => Value = value;

    public static OrderItemId Of(Guid value)
    {
        return new OrderItemId(value);
    }

}
