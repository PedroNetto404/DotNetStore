using System;
using DotNetStore.ApplicationCore.Abstractions;

namespace DotNetStore.ApplicationCore.Entities;

public sealed class Order : Entity
{
    private readonly List<OrderItem> _items = [];

    public Guid BuyerId { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; }
}

public enum OrderStatus
{
    Draft,
    Cancelled,
    InDelivery,
    Completed
}

public sealed class OrderItem : Entity
{

}