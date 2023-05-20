using Xunit;

namespace CardValidator.Tests;

public class CardDataTests
{
    [Fact]
    public void BrandConfigurations_DoNotContainDuplicates()
    {
        var brandConfigurations = CardData.BrandConfigurations;

        foreach (var kvp in brandConfigurations)
        {
            var cardInfo = kvp.Value;

            foreach (var configuration in cardInfo.Configurations)
            {
                var lengths = configuration.Lengths;
                var prefixes = configuration.Prefixes;

                for (int i = 0; i < lengths.Count; i++)
                {
                    for (int j = 0; j < prefixes.Count; j++)
                    {
                        for (int k = i + 1; k < lengths.Count; k++)
                        {
                            for (int l = j + 1; l < prefixes.Count; l++)
                            {
                                Assert.NotEqual($"{lengths[i]}_{prefixes[j]}", $"{lengths[k]}_{prefixes[l]}");
                            }
                        }
                    }
                }
            }
        }
    }
}