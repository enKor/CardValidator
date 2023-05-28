using CardValidator;

// 16 number Visa from String
string visaCardNumber = "4205 2245 9865 9069";
CreditCard visaCard = new CreditCard(visaCardNumber);
Console.WriteLine(visaCard);

// 15 number AmEx from Span
ReadOnlySpan<char> americanExpressCardNumberSpan = "347554301215479".AsSpan();
CreditCard amExCard = new CreditCard(americanExpressCardNumberSpan);
Console.WriteLine(amExCard);

// 16 number AmEx without length check
string americanExpressCardLonger = "3475543012154790";
CreditCard amExCard2 = new CreditCard(americanExpressCardLonger, true);
Console.WriteLine(amExCard2);

// invalid card number chars
try
{
    string invalidCardNumberChars = "ABC123456";
    CreditCard invalidCharsCard = new CreditCard(invalidCardNumberChars);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

// Luhn check
string visaCardNumber2 = "4205 2245 9865 9069";
CreditCard visaCard2 = new CreditCard(visaCardNumber);
// Valid Luhn for Visa
Console.WriteLine(visaCard.IsValid(CardIssuer.Visa));
// Valid Luhn for at least one of Visa or MasterCard
Console.WriteLine(visaCard.IsValid(CardIssuer.Visa, CardIssuer.MasterCard));
// Invalid Luhn for MasterCard
Console.WriteLine(visaCard.IsValid(CardIssuer.MasterCard));
