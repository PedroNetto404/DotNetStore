using DotNetStore.ApplicationCore.Exceptions;
using DotNetStore.ApplicationCore.Orders.Entities;

namespace DotNetStore.Tests;

public class OrdersTests
{
    [Fact]
    public void AddItem_WhenNegativeQuantityPassed_MustThrowDomainException()
    {
        //arrange
        var order = Order.Draft(Guid.NewGuid());

        //Act, Assert
        var raisedException = Assert.Throws<DomainException>(
            () =>
            {
                order.AddItem(Guid.NewGuid(), 100m, -1);
            }
        );

        Console.WriteLine(raisedException.Message);
    }
}
