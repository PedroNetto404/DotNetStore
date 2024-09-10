using DotNetStore.ApplicationCore.Abstractions;

namespace DotNetStore.ApplicationCore.Orders.Entities;

public sealed class OrderItem : Entity
{
    public int Quantity { get; private set; }
    public decimal ProductPrice { get; private set; }
    public Guid ProductId { get; private set; }
    public decimal Total => Quantity * ProductPrice;

    internal OrderItem
    (
        Guid productId,
        decimal productPrice,
        int quantity
    ) => (ProductId, ProductPrice, Quantity) = (productId, productPrice, quantity);

    internal void IncrementQuantity(int quantity) => Quantity += Math.Abs(quantity);

    internal void DecrementQuantity(int value) => Quantity -= Math.Abs(value);
}