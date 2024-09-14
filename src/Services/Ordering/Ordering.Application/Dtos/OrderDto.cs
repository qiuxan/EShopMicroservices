using Ordering.Domain.Enums;

namespace Ordering.Application.Dtos;

public record OderDto
    (
        Guid Id,
        Guid CustomerId,
        string OrderName,
        AddressDto ShippingAddress,
        AddressDto BillingAddress,
        PaymentDto Payment,
        OrderStatus Status,
        List<OrderItemDto> OrderItems
    );