using CardValidator.Configurations;
using CardValidator.Helpers;
using EnKor;

namespace CardValidator;

public record CreditCard
{
    public string Number => _unifiedCardNumberFormat;
    private readonly string _unifiedCardNumberFormat;

    public CardIssuer Issuer { get; private set; }

    public string Category => _category ??= IssuerCategory.Identifiers[Number[0]];
    private string? _category;
    
    public CreditCard(ReadOnlySpan<char> cardNumber, bool ignoreCardNumberLength = false)
    {
        if (!cardNumber.IsValidFormat(out _unifiedCardNumberFormat))
        {
            throw new ArgumentException("Invalid card number. Numbers and \" \" (space) allowed.");
        }

        Load(ignoreCardNumberLength);
    }

    public bool IsValid() => CardData.BrandConfigurations[Issuer].SkipLuhn || Luhn.IsValid(Number);

    public bool IsValid(params CardIssuer[] issuers)
    {
        for (var i = 0; i < issuers.Length; i++)
        {
            if (issuers[i] == Issuer && IsValid())
            {
                return true;
            }
        }

        return false;
    }
    
    private void Load(bool ignoreNumberLength)
    {
        foreach (var brandData in CardData.BrandConfigurations)
        {
            var cardInfo = brandData.Value;

            for (var index = 0; index < cardInfo.Configurations.Count; index++)
            {
                var rule = cardInfo.Configurations[index];
                if (rule.Prefixes.Any(c => Number.StartsWith(c))
                    && (ignoreNumberLength || rule.Lengths.Any(c => c == Number.Length)))
                {
                    Issuer = brandData.Key;
                    return;
                }
            }
        }

        Issuer = CardIssuer.Unknown;
    }
}