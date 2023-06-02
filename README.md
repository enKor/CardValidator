
# CardValidator
## Description
This nuget contains performant **credit card validator** based on card number.

It checks **number length and numeric prefixes** according to issuer (*AmericanExpress, ChinaUnionPay, Dankort, DinersClub, Discover, Hipercard, JCB, Laser, Maestro, MasterCard, RuPay, Switch, Visa*). For respective issuers it checks if it is **valid to Luhn** algorythm.

This nuget focuses on the **performance**. 

## Examples

### 16 number Visa from String

    string visaCardNumber = "4205 2245 9865 9069";
    CreditCard visaCard = new CreditCard(visaCardNumber);
    Console.WriteLine(visaCard);

### 15 number AmEx from Span

    ReadOnlySpan<char> americanExpressCardNumberSpan = "347554301215479".AsSpan();
    CreditCard amExCard = new CreditCard(americanExpressCardNumberSpan);
    Console.WriteLine(amExCard);

### 16 number AmEx without length check

    string americanExpressCardLonger = "3475543012154790";
    CreditCard amExCard2 = new CreditCard(americanExpressCardLonger, true);
    Console.WriteLine(amExCard2);

### Invalid card number characters

    try
    {
        string invalidCardNumberChars = "ABC123456";
        CreditCard invalidCharsCard = new CreditCard(invalidCardNumberChars);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        // ---> Invalid card number. Numbers and " " (space) allowed.
    }

### Luhn check
#### Valid Luhn for Visa

    Console.WriteLine(visaCard.IsValid(CardIssuer.Visa));
    // ---> True

#### Valid Luhn for at least one of Visa or MasterCard

    Console.WriteLine(visaCard.IsValid(CardIssuer.Visa, CardIssuer.MasterCard));
    // ---> True

#### Invalid Luhn for MasterCard

    Console.WriteLine(visaCard.IsValid(CardIssuer.MasterCard));
    // ---> False    


## Changelog
- **1.2.0**
  - Added vaidation helpers methods (*IsValidNumber*, *IsValidFormat*)
- **1.1.1** 
  - MasterCard specification fixed
  - Added demo examples
- **1.1.0** - Performance enhancement: 
  - *IsValid(params CardIssuer[] issuers)* method perf enhancement - 5.5x faster and half memory allocation then in v1.0.0
  - Faster creation of *CreditCard* object (*Load()* method optimized)
  - Removed redundant string allocation in *CreditCard* CTOR
- **1.0.0** - Init version - card validation
