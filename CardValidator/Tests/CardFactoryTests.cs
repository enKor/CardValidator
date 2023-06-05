using CardValidator.Configurations;
using CardValidator.Helpers;
using System.Linq;
using Xunit;

namespace CardValidator.Tests;

public class CardFactoryTests
{
    [Theory]
    [InlineData(CardIssuer.Visa)]
    [InlineData(CardIssuer.MasterCard)]
    [InlineData(CardIssuer.ChinaUnionPay)]
    [InlineData(CardIssuer.AmericanExpress)]
    [InlineData(CardIssuer.Maestro)]
    [InlineData(CardIssuer.Dankort)]
    [InlineData(CardIssuer.DinersClub)]
    [InlineData(CardIssuer.Discover)]
    [InlineData(CardIssuer.Hipercard)]
    [InlineData(CardIssuer.JCB)]
    [InlineData(CardIssuer.Laser)]
    [InlineData(CardIssuer.RuPay)]
    [InlineData(CardIssuer.Switch)]
    public void GenerateRandomCardNumber_ReturnsNonEmptyString(CardIssuer issuer)
    {
        // Act
        var cardNumber = CardFactory.GenerateRandomCardNumber(issuer);

        // Assert
        Assert.NotEmpty(cardNumber);
    }

    [Theory]
    [InlineData(CardIssuer.Visa)]
    [InlineData(CardIssuer.MasterCard)]
    [InlineData(CardIssuer.ChinaUnionPay)]
    [InlineData(CardIssuer.AmericanExpress)]
    [InlineData(CardIssuer.Maestro)]
    [InlineData(CardIssuer.Dankort)]
    [InlineData(CardIssuer.DinersClub)]
    [InlineData(CardIssuer.Discover)]
    [InlineData(CardIssuer.Hipercard)]
    [InlineData(CardIssuer.JCB)]
    [InlineData(CardIssuer.Laser)]
    [InlineData(CardIssuer.RuPay)]
    [InlineData(CardIssuer.Switch)]
    public void GenerateRandomCardNumber_CanLoadValidCreditCard(CardIssuer issuer)
    {
        // Act
        var cardNumber = CardFactory.GenerateRandomCardNumber(issuer);

        // Assert
        var cc = new CreditCard(cardNumber);
        var isValid = cc.IsValid(issuer);
        Assert.Equal(issuer, cc.Issuer);
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(CardIssuer.Visa)]
    [InlineData(CardIssuer.MasterCard)]
    [InlineData(CardIssuer.ChinaUnionPay)]
    [InlineData(CardIssuer.AmericanExpress)]
    [InlineData(CardIssuer.Maestro)]
    [InlineData(CardIssuer.Dankort)]
    [InlineData(CardIssuer.DinersClub)]
    [InlineData(CardIssuer.Discover)]
    [InlineData(CardIssuer.Hipercard)]
    [InlineData(CardIssuer.JCB)]
    [InlineData(CardIssuer.Laser)]
    [InlineData(CardIssuer.RuPay)]
    [InlineData(CardIssuer.Switch)]
    public void GenerateRandomCardNumber_CanAssignToCardConfig(CardIssuer issuer)
    {
        // Act
        var cardNumber = CardFactory.GenerateRandomCardNumber(issuer);

        // Assert
        var cfg = CardData
            .BrandConfigurations[issuer]
            .Configurations
            .Where(x =>
                x.Lengths.Contains(cardNumber.Length) &&
                x.Prefixes.Any(p => cardNumber.StartsWith(p)));
        Assert.Single(cfg);
    }
}