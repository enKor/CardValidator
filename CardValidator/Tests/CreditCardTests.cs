using System;
using Xunit;

namespace CardValidator.Tests;

public class CreditCardTests
{
    [Fact]
    public void Constructor_WithValidCardNumber_SetsNumberAndCategory()
    {
        // Arrange
        var cardNumber = "4111111111111111".AsSpan();

        // Act
        var creditCard = new CreditCard(cardNumber);

        // Assert
        Assert.Equal("4111111111111111", creditCard.Number);
        Assert.Equal("Banking and financial", creditCard.Category);
    }

    [Fact]
    public void Constructor_WithInvalidCardNumber_ThrowsArgumentException()
    {
        // Arrange
        var cardNumber = "12345678 abcd";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new CreditCard(cardNumber));
    }

    [Fact]
    public void IsValid_WithValidCard_ReturnsTrue()
    {
        // Arrange
        var cardNumber = "4111111111111111".AsSpan();
        var creditCard = new CreditCard(cardNumber);

        // Act
        var result = creditCard.IsValid();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValid_WithInvalidCard_ReturnsFalse()
    {
        // Arrange
        var cardNumber = "1234567890123456".AsSpan();
        var creditCard = new CreditCard(cardNumber);

        // Act
        var result = creditCard.IsValid();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValid_WithValidIssuers_ReturnsTrue()
    {
        // Arrange
        var cardNumber = "4111111111111111".AsSpan();
        var creditCard = new CreditCard(cardNumber);

        // Act
        var result = creditCard.IsValid(CardIssuer.Visa, CardIssuer.MasterCard);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValid_WithInvalidIssuers_ReturnsFalse()
    {
        // Arrange
        var cardNumber = "4111111111111111".AsSpan();
        var creditCard = new CreditCard(cardNumber);

        // Act
        var result = creditCard.IsValid(CardIssuer.AmericanExpress, CardIssuer.Discover);

        // Assert
        Assert.False(result);
    }
}