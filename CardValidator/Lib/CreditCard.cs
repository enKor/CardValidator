using CardValidator.Configurations;
using CardValidator.Helpers;
using EnKor;

namespace CardValidator;

public record CreditCard
{
    public string Number { get; }

    public CardIssuer Issuer { get; private set; }

    public string Category => _category ??= IssuerCategory.Identifiers[Number[0]];
    private string? _category;

    private bool? _isLuhnValid;
    
    public CreditCard(ReadOnlySpan<char> cardNumber, bool ignoreCardNumberLength = false)
    {
        if (!cardNumber.IsValidFormat(out var unifiedCardNumberFormat))
        {
            throw new ArgumentException("Invalid card number. Numbers and \" \" (space) allowed.");
        }

        Number = unifiedCardNumberFormat!;

        Load(ignoreCardNumberLength);
    }

    public bool IsValid() =>
        CardData.BrandConfigurations[Issuer].SkipLuhn ||
        (_isLuhnValid ??= Luhn.IsValid(Number));

    public bool IsValid(params CardIssuer[] issuers)
    {
        for (var index = 0; index < issuers.Length; index++)
        {
            var issuer = issuers[index];
            if (issuer == Issuer && IsValid()) return true;
        }

        return false;
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