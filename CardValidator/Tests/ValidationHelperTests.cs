using System;
using CardValidator.Helpers;
using Xunit;
// ReSharper disable InlineOutVariableDeclaration

namespace CardValidator.Tests;

public class ValidationHelperTests
{
    [Fact]
    public void IsValidFormat_ValidFormat_ReturnsTrueAndCleanCardNumber()
    {
        // Arrange
        var input = "1234 5678 9012 3456".AsSpan();
        string cleanCardNumber;

        // Act
        var result = input.IsValidFormat(out cleanCardNumber);

        // Assert
        Assert.True(result);
        Assert.Equal("1234567890123456", cleanCardNumber);
    }

    [Fact]
    public void IsValidFormat_InvalidFormat_ReturnsFalseAndNullCleanCardNumber()
    {
        // Arrange
        var input = "12ab34 5678 9012 3456".AsSpan();
        string cleanCardNumber;

        // Act
        var result = input.IsValidFormat(out cleanCardNumber);

        // Assert
        Assert.False(result);
        Assert.Equal(string.Empty, cleanCardNumber);
    }

    [Fact]
    public void IsValidFormat_ValidFormat_PublicOverload()
    {
        // Arrange
        var input = "1234 5678 9012 3456".AsSpan();

        // Act
        var result = ValidationHelper.IsValidFormat(input);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidFormat_InvalidFormat_PublicOverload()
    {
        // Arrange
        var input = "12ab34 5678 9012 3456".AsSpan();

        // Act
        var result = ValidationHelper.IsValidFormat(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsValidFormat_ValidNumber()
    {
        // Arrange
        var input = "4916123456789012340".AsSpan();
        var issuer = CardIssuer.Visa;

        // Act
        var result = ValidationHelper.IsValidNumber(input, issuer);

        // Assert
        Assert.True(result);
    }
}