using CardValidator.Helpers;

namespace CardValidator.Examples;

internal static class Program
{
    private static void Main(string[] args)
    {
        ValidateVisaCardNumber();
        ValidateAmExCardNumber();
        ValidateAmExCardNumberWithoutLengthCheck();
        ValidateInvalidCardNumberChars();
        ValidateLuhnCheck();
        ValidateCardNumberByIssuer();
        ValidateCardNumberByValidationHelper();
        GenerateRandomCardNumberForIssuer();

        Console.ReadLine();
    }

    public static void ValidateVisaCardNumber()
    {
        string visaCardNumber = "4205 2245 9865 9069";
        CreditCard visaCard = new CreditCard(visaCardNumber);
        Console.WriteLine(visaCard);
    }

    public static void ValidateAmExCardNumber()
    {
        ReadOnlySpan<char> americanExpressCardNumberSpan = "347554301215479".AsSpan();
        CreditCard amExCard = new CreditCard(americanExpressCardNumberSpan);
        Console.WriteLine(amExCard);
    }

    public static void ValidateAmExCardNumberWithoutLengthCheck()
    {
        string americanExpressCardLonger = "3475543012154790";
        CreditCard amExCard2 = new CreditCard(americanExpressCardLonger, true);
        Console.WriteLine(amExCard2);
    }

    public static void ValidateInvalidCardNumberChars()
    {
        try
        {
            string invalidCardNumberChars = "ABC123456";
            CreditCard invalidCharsCard = new CreditCard(invalidCardNumberChars);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void ValidateLuhnCheck()
    {
        string visaCardNumber2 = "4205 2245 9865 9069";
        CreditCard visaCard2 = new CreditCard(visaCardNumber2);

        // Valid Luhn for Visa
        Console.WriteLine(visaCard2.IsValid(CardIssuer.Visa));

        // Valid Luhn for at least one of Visa or MasterCard
        Console.WriteLine(visaCard2.IsValid(CardIssuer.Visa, CardIssuer.MasterCard));

        // Invalid Luhn for MasterCard
        Console.WriteLine(visaCard2.IsValid(CardIssuer.MasterCard));
    }

    public static void ValidateCardNumberByIssuer()
    {
        ReadOnlySpan<char> cardNumber = "4111111111111111".AsSpan();
        bool isValid1 = ValidationHelper.IsValidNumber(cardNumber, CardIssuer.Visa);
        Console.WriteLine(isValid1);
        // ---> True
    }

    public static void ValidateCardNumberByValidationHelper()
    {
        bool isValid2 = ValidationHelper.IsValidFormat("4111111111111111");
        Console.WriteLine(isValid2);
        // ---> True
    }

    public static void GenerateRandomCardNumberForIssuer()
    {
        string randomCardNumber = CardFactory.GenerateRandomCardNumber(CardIssuer.Visa);
        Console.WriteLine(randomCardNumber);
        // ---> Randomly generated card number for the specified issuer
    }
        
}