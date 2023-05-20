namespace CardValidator;

public record CreditCard
{
    public string Number { get; }
    public CardIssuer Issuer { get; private set; }
    
    public CreditCard(ReadOnlySpan<char> cardNumber, bool ignoreCardNumberLength = false)
    {
        if (!cardNumber.IsValidFormat(out var unifiedCardNumberFormat))
        {
            throw new ArgumentException("Invalid card number. Numbers and \" \" (space) allowed.");
        }

        Number = unifiedCardNumberFormat!;

        Load(ignoreCardNumberLength);
    }

    private void Load(bool ignoreNumberLength)
    {
        foreach (var brandData in CardData.BrandConfigurations)
        {
            var cardInfo = brandData.Value;

            foreach (var rule in cardInfo.Configurations)
            {
                if (rule.Prefixes.Any(c => Number.StartsWith(c))
                   && (ignoreNumberLength || rule.Lengths.Any(c => c == Number.Length)) )
                {
                    Issuer = brandData.Key;
                    return;
                }
            }
        }

        Issuer = CardIssuer.Unknown;
    }
}