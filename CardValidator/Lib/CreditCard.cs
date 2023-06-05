using CardValidator.Configurations;
using CardValidator.Helpers;
using EnKor;

namespace CardValidator;

/// <summary>
/// Represents a credit card with validation and identification capabilities.
/// </summary>
public record CreditCard
{
    /// <summary>
    /// Gets the card number.
    /// </summary>
    public string Number => _unifiedCardNumberFormat;
    private readonly string _unifiedCardNumberFormat;

    /// <summary>
    /// Gets the issuer of the card.
    /// </summary>
    public CardIssuer Issuer { get; private set; }

    /// <summary>
    /// Gets the category of the card based on its first digit.
    /// </summary>
    public string Category => _category ??= IssuerCategory.Identifiers[Number[0]];
    private string? _category;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreditCard"/> class.
    /// </summary>
    /// <param name="cardNumber">The credit card number.</param>
    /// <param name="ignoreCardNumberLength">Specifies whether to ignore the card number length during validation.</param>
    /// <exception cref="ArgumentException">Thrown when the card number is invalid.</exception>
    public CreditCard(ReadOnlySpan<char> cardNumber, bool ignoreCardNumberLength = false)
    {
        if (!cardNumber.IsValidFormat(out _unifiedCardNumberFormat))
        {
            throw new ArgumentException("Invalid card number. Numbers and \" \" (space) allowed.");
        }

        Load(ignoreCardNumberLength);
    }

    /// <summary>
    /// Checks if the credit card number is valid.
    /// </summary>
    /// <returns><c>true</c> if the card number is valid, otherwise <c>false</c>.</returns>
    public bool IsValid() => CardData.BrandConfigurations[Issuer].SkipLuhn || Luhn.IsValid(Number);

    /// <summary>
    /// Checks if the credit card number is valid for the specified issuers.
    /// </summary>
    /// <param name="issuers">The card issuers to validate against.</param>
    /// <returns><c>true</c> if the card number is valid for any of the specified issuers, otherwise <c>false</c>.</returns>
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