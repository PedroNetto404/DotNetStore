using DotNetStore.ApplicationCore.Buyers;

namespace DotNetStore.Tests;

public class BuyerTests
{
    [Fact]
    public void Buyer_Age_MustBeValid()
    {
        //arrange
        var buyer = new Buyer(
            string.Empty,
            string.Empty,
            string.Empty,
            new DateOnly(2000, 08, 29)
        );

        //act
        var age = buyer.Age;

        //assert
        Assert.Equal(expected: 24, age);
    }
}