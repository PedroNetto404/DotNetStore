
using DotNetStore.ApplicationCore.Exceptions;

namespace DotNetStore.ApplicationCore.Orders;

public static class OrderExceptions
{
    public static void GuardNonNegativeQuantity(int quantity) =>
        DomainException.GreatherThan
        (
            quantity,
            0,
            "orders",
            "Item quantity must be greather than zero."
        );

    public static void GuardLessQuantityThenCurrent(int currentQuantity, int newQuantity) =>
        DomainException.GreatherThan
        (
            currentQuantity,
            newQuantity,
            "orders",
            "New quantity must be less than current quantity"
        );
}
