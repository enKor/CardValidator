using EnKor;

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

    public bool IsValid() => CardData.BrandConfigurations[Issuer].SkipLuhn || Luhn.IsValid(Number);

    // TODO perf
    public bool IsValid(params CardIssuer[] issuers) => issuers.Any(issuer => issuer == Issuer && IsValid());

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