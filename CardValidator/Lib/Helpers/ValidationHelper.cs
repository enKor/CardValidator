using CardValidator.Configurations;
using EnKor;
using System.Runtime.CompilerServices;

namespace CardValidator.Helpers;

public static class ValidationHelper
{
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