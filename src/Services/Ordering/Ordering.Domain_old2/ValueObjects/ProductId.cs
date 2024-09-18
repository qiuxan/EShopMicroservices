﻿namespace Ordering.Domain.ValueObjects;
public class ProductId
{
    public Guid Value { get; }
    private ProductId(Guid value) => Value = value;

    public static ProductId Of(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new DomainException("Product id cannot be empty.");
        }

        return new ProductId(value);
    }


}
