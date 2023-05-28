using Xunit;

namespace CardValidator.Tests;

public class CardIsNotValidTests
{
    private static void AssertValidCard(string cardNumber, CardIssuer issuer) =>
        Assert.False(new CreditCard(cardNumber).IsValid(issuer));

    [Theory]
    [InlineData("4111111111110")] // Visa, length: 13, prefix: 4
    [InlineData("4111111111111110")] // Visa, length: 16, prefix: 4
    [InlineData("4916123456789012341")] // Visa, length: 19, prefix: 4
    public void Visa_CardNumberIsNotValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.Visa);

    [Theory]
    [InlineData("5212345678901230")] // MasterCard, length: 16, prefix: 52
    [InlineData("2222123456789010")] // MasterCard, length: 16, prefix: 2222
    public void MasterCard_CardNumberIsNotValid(string cardNumber) =>
        AssertValidCard(cardNumber, CardIssuer.MasterCard);

    [Theory]
    [InlineData("340000000000000")] // American Express, length: 15, prefix: 34
    [InlineData("370000000000000")] // American Express, length: 15, prefix: 37
    public void AmericanExpress_CardNumberIsNotValid(string cardNumber) =>
        AssertValidCard(cardNumber, CardIssuer.AmericanExpress);

    [Theory]
    [InlineData("38345678901230")] // Diners Club, length: 14, prefix: 38
    [InlineData("3809123456789010")] // Diners Club, length: 16, prefix: 38
    [InlineData("36012345678900")] // Diners Club, length: 14, prefix: 36
    [InlineData("3629123456789000")] // Diners Club, length: 16, prefix: 36
    [InlineData("30952345678900")] // Diners Club, length: 14, prefix: 3095
    [InlineData("3095123456789010")] // Diners Club, length: 16, prefix: 3095
    public void DinersClub_CardNumberIsNotValid(string cardNumber) =>
        AssertValidCard(cardNumber, CardIssuer.DinersClub);

    [Theory]
    [InlineData("6011123456789013")] // Discover, length: 16, prefix: 6011
    [InlineData("6549123456789011")] // Discover, length: 16, prefix: 65
    public void Discover_CardNumberIsNotValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.Discover);

    [Theory]
    [InlineData("352812345678901")] // JCB, length: 15, prefix: 3528
    [InlineData("352912345678901")] // JCB, length: 15, prefix: 3529
    [InlineData("353012345678901")] // JCB, length: 15, prefix: 3530
    [InlineData("180012345678901")] // JCB, length: 15, prefix: 1800
    [InlineData("213112345678901")] // JCB, length: 15, prefix: 2131
    [InlineData("3528123456789010")] // JCB, length: 16, prefix: 3528
    [InlineData("3529123456789019")] // JCB, length: 16, prefix: 3529
    [InlineData("3530123456789017")] // JCB, length: 16, prefix: 3530
    [InlineData("3572661234567890180")] // JCB, length: 19, prefix: 357266
    public void JCB_CardNumberIsNotValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.JCB);

    [Theory]
    [InlineData("6304123456789010")] // Laser, length: 16, prefix: 6304
    [InlineData("63041234567890150")] // Laser, length: 17, prefix: 6304
    [InlineData("630412345678901510")] // Laser, length: 18, prefix: 6304
    [InlineData("6304123456789015180")] // Laser, length: 19, prefix: 6304
    public void Laser_CardNumberIsNotValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.Laser);

    [Theory]
    [InlineData("6331101234567890")] // Switch, length: 16, prefix: 633110
    [InlineData("6333121234567890")] // Switch, length: 16, prefix: 633312
    [InlineData("6333041234567890")] // Switch, length: 16, prefix: 633304
    [InlineData("6333031234567890")] // Switch, length: 16, prefix: 633303
    [InlineData("6333011234567890")] // Switch, length: 16, prefix: 633301
    [InlineData("6333001234567890")] // Switch, length: 16, prefix: 633300
    [InlineData("633110123456789011")] // Switch, length: 18, prefix: 633110
    [InlineData("633312123456789011")] // Switch, length: 18, prefix: 633312
    [InlineData("633304123456789011")] // Switch, length: 18, prefix: 633304
    [InlineData("633303123456789011")] // Switch, length: 18, prefix: 633303
    [InlineData("633301123456789011")] // Switch, length: 18, prefix: 633301
    [InlineData("633300123456789011")] // Switch, length: 18, prefix: 633300
    [InlineData("6331101234567890123")] // Switch, length: 19, prefix: 633110
    [InlineData("6333121234567890123")] // Switch, length: 19, prefix: 633312
    [InlineData("6333041234567890123")] // Switch, length: 19, prefix: 633304
    [InlineData("6333031234567890123")] // Switch, length: 19, prefix: 633303
    [InlineData("6333011234567890123")] // Switch, length: 19, prefix: 633301
    [InlineData("6333001234567890123")] // Switch, length: 19, prefix: 633300
    public void Switch_CardNumberIsNotValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.Switch);

    [Theory]
    [InlineData("5019123456789010")] // Dankort, length: 16, prefix: 5019
    public void Dankort_CardNumberIsNotValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.Dankort);
}