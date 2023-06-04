﻿using CardValidator.Configurations;

namespace CardValidator.Helpers;

public static class CardFactory
{
    private static readonly Random Random = new();

    public static string GenerateRandomCardNumber(CardIssuer issuer)
    {
        var cardInfo = CardData.BrandConfigurations[issuer];
        var randomCfgIdx = Random.Next(0, cardInfo.Configurations.Count);
        var randomCardLengthIdx = Random.Next(0, cardInfo.Configurations[randomCfgIdx].Lengths.Count);
        var randomCardLength = cardInfo.Configurations[randomCfgIdx].Lengths[randomCardLengthIdx];
        var randomCardPrefixIdx = Random.Next(0, cardInfo.Configurations[randomCfgIdx].Prefixes.Count);
        var randomCardPrefix = cardInfo.Configurations[randomCfgIdx].Prefixes[randomCardPrefixIdx];

        var lengthToGenerate = cardInfo.SkipLuhn ? randomCardLength : randomCardLength - 1;

        Span<char> start = stackalloc char[lengthToGenerate];
        start.Fill('0');
        Span<char> end = stackalloc char[lengthToGenerate];
        end.Fill('9');

        for (int i = 0; i < randomCardPrefix.Length; i++)
        {
            start[i] = randomCardPrefix[i];
            end[i] = randomCardPrefix[i];
        }

        var random = Random.NextInt64(long.Parse(start), long.Parse(end) + 1).ToString();

        if (cardInfo.SkipLuhn)
        {
            return random;
        }

        var checkDigit = EnKor.Luhn.CalculateCheckDigit(random.AsSpan()[..^1]);
        return $"{random}{checkDigit}";
    }
}