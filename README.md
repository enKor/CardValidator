# CardValidator
## Description
This nuget contains performant **credit card validator** based on card number.

It checks **number length and numeric prefixes** according to issuer (*AmericanExpress,    ChinaUnionPay,    Dankort,    DinersClub,    Discover,    Hipercard,    JCB,    Laser,    Maestro,    MasterCard,    RuPay,    Switch,    Visa*). For respective issuers it checks if it is **valid to Luhn** algorythm.

Except of the validation features, this nuget focuses on the **performance** a lot. 

## Changelog
x.x.x - Call Luhn algorythm only once per card number
1.0.0 - Init version - card validation