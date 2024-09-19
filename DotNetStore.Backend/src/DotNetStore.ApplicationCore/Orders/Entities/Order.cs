using DotNetStore.ApplicationCore.Abstractions;
using DotNetStore.ApplicationCore.Exceptions;
using DotNetStore.ApplicationCore.Orders.Enums;

namespace DotNetStore.ApplicationCore.Orders.Entities;

public sealed class Order : Entity
{
    private readonly List<OrderItem> _items = [];

    public Guid BuyerId { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAtUtc { get; private set; }

    private Order
    (
        Guid buyerId,
        params OrderItem[] items
    )
    {
        BuyerId = buyerId;
        _items.AddRange(items);

        Status = OrderStatus.Draft;
    }

    public static Order Draft
    (
        Guid buyerId,
        params OrderItem[] items
    )
    {
        DomainException.NotEqual(buyerId, Guid.Empty, "orders", "Invalid buyer id");
        return new Order(buyerId, items);
    }

    public void AddItem
    (
        Guid productId,
        decimal productPrice,
        int quantity
    )
    {
        OrderExceptions.GuardNonNegativeQuantity(quantity);

        var existingItem = _items.SingleOrDefault(p => p.ProductId == productId);
        if (existingItem is not null)
        {
            existingItem.IncrementQuantity(quantity);
            return;
        }

        _items.Add(new(productId, productPrice, quantity));
    }

    public void RemoveItem
    (
        Guid productId,
        int? quantity = null
    )
    {
        var item = _items.Single(p => p.ProductId == productId);

        if (quantity is not null)
        {
            OrderExceptions.GuardNonNegativeQuantity(quantity.Value);
            OrderExceptions.GuardLessQuantityThenCurrent(item.Quantity, quantity.Value);

            item.DecrementQuantity(quantity.Value);
            return;
        }

        _items.Remove(item);
    }
}
