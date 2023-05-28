using Xunit;

namespace CardValidator.Tests;

public class CardIsValidTests
{
    private static void AssertValidCard(string cardNumber, CardIssuer issuer) => 
        Assert.True(new CreditCard(cardNumber).IsValid(issuer));

    [Theory]
    [InlineData("4111111111119")] // Visa, length: 13, prefix: 4
    [InlineData("4111111111111111")] // Visa, length: 16, prefix: 4
    [InlineData("4916123456789012340")] // Visa, length: 19, prefix: 4
    public void Visa_CardNumberIsValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.Visa);

    [Theory]
    [InlineData("5212345678901234")] // MasterCard, length: 16, prefix: 52
    [InlineData("2222123456789013")] // MasterCard, length: 16, prefix: 2222
    public void MasterCard_CardNumberIsValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.MasterCard);

    [Theory]
    [InlineData("340000000000009")] // American Express, length: 15, prefix: 34
    [InlineData("370000000000002")] // American Express, length: 15, prefix: 37
    public void AmericanExpress_CardNumberIsValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.AmericanExpress);

    [Theory]
    [InlineData("38345678901237")] // Diners Club, length: 14, prefix: 38
    [InlineData("3809123456789012")] // Diners Club, length: 16, prefix: 38
    [InlineData("36012345678901")] // Diners Club, length: 14, prefix: 36
    [InlineData("3629123456789010")] // Diners Club, length: 16, prefix: 36
    [InlineData("30952345678904")] // Diners Club, length: 14, prefix: 3095
    [InlineData("3095123456789015")] // Diners Club, length: 16, prefix: 3095
    public void DinersClub_CardNumberIsValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.DinersClub);

    [Theory]
    [InlineData("6011123456789019")] // Discover, length: 16, prefix: 6011
    [InlineData("6549123456789010")] // Discover, length: 16, prefix: 65
    public void Discover_CardNumberIsValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.Discover);

    [Theory]
    [InlineData("352812345678900")] // JCB, length: 15, prefix: 3528
    [InlineData("352912345678908")] // JCB, length: 15, prefix: 3529
    [InlineData("353012345678906")] // JCB, length: 15, prefix: 3530
    [InlineData("180012345678905")] // JCB, length: 15, prefix: 1800
    [InlineData("213112345678904")] // JCB, length: 15, prefix: 2131
    [InlineData("3528123456789012")] // JCB, length: 16, prefix: 3528
    [InlineData("3529123456789011")] // JCB, length: 16, prefix: 3529
    [InlineData("3530123456789018")] // JCB, length: 16, prefix: 3530
    [InlineData("3572661234567890181")] // JCB, length: 19, prefix: 357266
    public void JCB_CardNumberIsValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.JCB);

    [Theory]
    [InlineData("6304123456789015")] // Laser, length: 16, prefix: 6304
    [InlineData("63041234567890151")] // Laser, length: 17, prefix: 6304
    [InlineData("630412345678901518")] // Laser, length: 18, prefix: 6304
    [InlineData("6304123456789015183")] // Laser, length: 19, prefix: 6304
    public void Laser_CardNumberIsValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.Laser);

    [Theory]
    [InlineData("6331101234567892")] // Switch, length: 16, prefix: 633110
    [InlineData("6333121234567898")] // Switch, length: 16, prefix: 633312
    [InlineData("6333041234567898")] // Switch, length: 16, prefix: 633304
    [InlineData("6333031234567899")] // Switch, length: 16, prefix: 633303
    [InlineData("6333011234567891")] // Switch, length: 16, prefix: 633301
    [InlineData("6333001234567892")] // Switch, length: 16, prefix: 633300
    [InlineData("633110123456789010")] // Switch, length: 18, prefix: 633110
    [InlineData("633312123456789016")] // Switch, length: 18, prefix: 633312
    [InlineData("633304123456789016")] // Switch, length: 18, prefix: 633304
    [InlineData("633303123456789017")] // Switch, length: 18, prefix: 633303
    [InlineData("633301123456789019")] // Switch, length: 18, prefix: 633301
    [InlineData("633300123456789010")] // Switch, length: 18, prefix: 633300
    [InlineData("6331101234567890120")] // Switch, length: 19, prefix: 633110
    [InlineData("6333121234567890122")] // Switch, length: 19, prefix: 633312
    [InlineData("6333041234567890129")] // Switch, length: 19, prefix: 633304
    [InlineData("6333031234567890121")] // Switch, length: 19, prefix: 633303
    [InlineData("6333011234567890125")] // Switch, length: 19, prefix: 633301
    [InlineData("6333001234567890127")] // Switch, length: 19, prefix: 633300
    public void Switch_CardNumberIsValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.Switch);

    [Theory]
    [InlineData("6212345678901232")] // China UnionPay, length: 18, prefix: 62
    [InlineData("62123456789012347")] // China UnionPay, length: 19, prefix: 62    [InlineData("621234567890123456")] // China UnionPay, length: 18, prefix: 62
    [InlineData("621234567890123457")] // China UnionPay, length: 19, prefix: 62    [InlineData("621234567890123456")] // China UnionPay, length: 18, prefix: 62
    [InlineData("6212345678901234569")] // China UnionPay, length: 19, prefix: 62
    public void ChinaUnionPay_CardNumberIsValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.ChinaUnionPay);

    [Theory]
    [InlineData("5019123456789013")] // Dankort, length: 16, prefix: 5019
    public void Dankort_CardNumberIsValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.Dankort);

    [Theory]
    [InlineData("6071123456789012")] // RuPay, length: 16, prefix: 6071
    [InlineData("6080123456789012")] // RuPay, length: 16, prefix: 6080
    [InlineData("6061123456789012")] // RuPay, length: 16, prefix: 6061
    [InlineData("6062123456789012")] // RuPay, length: 16, prefix: 6062
    [InlineData("6063123456789012")] // RuPay, length: 16, prefix: 6063
    [InlineData("6064123456789012")] // RuPay, length: 16, prefix: 6064
    [InlineData("6065123456789012")] // RuPay, length: 16, prefix: 6065
    [InlineData("6066123456789012")] // RuPay, length: 16, prefix: 6066
    [InlineData("6067123456789012")] // RuPay, length: 16, prefix: 6067
    [InlineData("6068123456789012")] // RuPay, length: 16, prefix: 6068
    [InlineData("6069123456789012")] // RuPay, length: 16, prefix: 6069
    public void RuPay_CardNumberIsValid(string cardNumber) => AssertValidCard(cardNumber, CardIssuer.RuPay);
}