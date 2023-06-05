using CardValidator.Configurations;
using EnKor;
using System.Runtime.CompilerServices;

namespace CardValidator.Helpers;

/// <summary>
/// Provides helper methods for validating credit card numbers.
/// </summary>
public static class ValidationHelper
{
    /// <summary>
    /// Determines whether the specified credit card number is valid for the given issuer.
    /// </summary>
    /// <param name="cardNumber">The credit card number to validate.</param>
    /// <param name="issuer">The card issuer.</param>
    /// <returns><c>true</c> if the card number is valid for the given issuer; otherwise, <c>false</c>.</returns>
    public static bool IsValidNumber(ReadOnlySpan<char> cardNumber, CardIssuer issuer)
    {
        var info = CardData.BrandConfigurations[issuer];
        var configs = info.Configurations;

        for (int cfgIdx = 0; cfgIdx < configs.Count; cfgIdx++)
        {
            var cfg = configs[cfgIdx];
            if (MatchLength(cardNumber, cfg.Lengths) && MatchesPrefix(cardNumber, cfg.Prefixes))
            {
                return info.SkipLuhn || Luhn.IsValid(cardNumber);
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether the specified string represents a valid card number format.
    /// </summary>
    /// <param name="cardNumber">The card number to validate.</param>
    /// <returns><c>true</c> if the card number has a valid format; otherwise, <c>false</c>.</returns>
    public static bool IsValidFormat(ReadOnlySpan<char> cardNumber) =>
        cardNumber.IsValidFormat(out _);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IsValidFormat(this ReadOnlySpan<char> input, out string cleanCardNumber)
    {
        Span<char> output = stackalloc char[input.Length];
        int outputIndex = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsNumber(input[i]))
            {
                output[outputIndex] = input[i];
                outputIndex++;
            }
            else if (!char.IsWhiteSpace(input[i]))
            {
                cleanCardNumber = string.Empty;
                return false;
            }
        }

        cleanCardNumber = output[..outputIndex].ToString();
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool MatchLength(ReadOnlySpan<char> cardNumber, IReadOnlyList<int> lengths)
    {
        for (int lenIdx = 0; lenIdx < lengths.Count; lenIdx++)
        {
            if (lengths[lenIdx] == cardNumber.Length)
            {
                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool MatchesPrefix(ReadOnlySpan<char> cardNumber, IReadOnlyList<string> prefixes)
    {
        for (int prefixIdx = 0; prefixIdx < prefixes.Count; prefixIdx++)
        {
            if (cardNumber.StartsWith(prefixes[prefixIdx]))
            {
                return true;
            }
        }

        return false;
    }
}