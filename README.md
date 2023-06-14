
# CardValidator

- [Description](#description)
- [Installation](#installation)
- [Usage](#usage)
  - [Creating a `CreditCard` object](#creating-a-creditcard-object)
  - [Checking card number validity](#checking-card-number-validity)
  - [Validation Helper Methods](#validation-helper-methods)
  - [CardFactory generator](#cardfactory-generator)
- [Changelog](#changelog)

---

## Description
**CardValidator** is a performant NuGet package that provides a **credit card validator** based on the **card number**. 
It focuses on checking the number length and numeric prefixes according to the issuer (such as *AmericanExpress, ChinaUnionPay, Dankort, DinersClub, Discover, Hipercard, JCB, Laser, Maestro, MasterCard, RuPay, Switch, Visa*). For each respective issuer, it also checks if the card number is valid according to the **Luhn** algorithm. The package is designed to **prioritize performance**.

## Installation
You can install the CardValidator NuGet package via the NuGet Package Manager or by using the following command in the Package Manager Console:

    Install-Package CardValidator


## Usage

### Creating a `CreditCard` object
You can create a `CreditCard` object by providing a card number as a `string` or a `ReadOnlySpan<char>`.

```csharp
// Example 1: Creating a CreditCard object from a string
string visaCardNumber = "4205 2245 9865 9069";
CreditCard visaCard = new CreditCard(visaCardNumber);
Console.WriteLine(visaCard);

// Example 2: Creating a CreditCard object from a ReadOnlySpan<char>
ReadOnlySpan<char> americanExpressCardNumberSpan = "347554301215479".AsSpan();
CreditCard amExCard = new CreditCard(americanExpressCardNumberSpan);
Console.WriteLine(amExCard);

// Example 3: Creating a CreditCard object without length check
string americanExpressCardLonger = "3475543012154790";
CreditCard amExCard2 = new CreditCard(americanExpressCardLonger, true);
Console.WriteLine(amExCard2);
```

### Checking card number validity

You can check the validity of a card number using the `IsValid` method of the `CreditCard` object.

```csharp
// Example 4: Checking validity for a specific issuer
Console.WriteLine(visaCard.IsValid(CardIssuer.Visa));
// ---> True

// Example 5: Checking validity for multiple issuers
Console.WriteLine(visaCard.IsValid(CardIssuer.Visa, CardIssuer.MasterCard));
// ---> True

// Example 6: Checking validity for an unsupported issuer
Console.WriteLine(visaCard.IsValid(CardIssuer.MasterCard));
// ---> False
```


### Validation Helper Methods

The `ValidationHelper` class provides additional helper methods for card number validation.

```csharp
// Example 7: Checking if a card number is valid based on issuer
ReadOnlySpan<char> cardNumber = "4111111111111111".AsSpan();
bool isValid = ValidationHelper.IsValidNumber(cardNumber, CardIssuer.Visa);
Console.WriteLine(isValid);
// ---> True

// Example 8: Checking if a card number is valid by ValidationHelper
bool isValid = ValidationHelper.IsValidFormat("4111111111111111");
Console.WriteLine(isValid);
// ---> True
```

### CardFactory generator
The `CardFactory` class provides method generating valid card number.

```
// Example: Generating a random card number for a specific issuer
string randomCardNumber = CardFactory.GenerateRandomCardNumber(CardIssuer.Visa); 
Console.WriteLine(randomCardNumber); 
// ---> Randomly generated card number for the specified issuer
```

## Changelog

-   **1.3.0**
	- Added `CardFactory` to generate valid random card numbers
-   **1.2.0**
    -   Added validation helper methods (`IsValidNumber`, `IsValidFormat`)
-   **1.1.1**
    -   Fixed MasterCard specification
    -   Added demo examples
-   **1.1.0**
    -   Performance enhancements:
        -   Improved performance of the `IsValid(params CardIssuer[] issuers)` method, making it 5.5x faster and reducing memory allocation compared to version 1.0.0
        -   Optimized the `Load()` method for faster creation of `CreditCard` objects
        -   Removed redundant string allocation in the `CreditCard` constructor
-   **1.0.0**
    -   Initial version with card validation functionality