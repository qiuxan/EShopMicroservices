namespace Ordering.Domain.ValueObjects;
public class OrderName
{
    private const int DefaultLength = 5;
    public string Value { get; }
    private OrderName(string value) => Value = value;

    public static OrderName Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, "Order name cannot be empty.");
        ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength, $"Order name must be {DefaultLength} characters long.");

        return new OrderName(value);
    }

}
