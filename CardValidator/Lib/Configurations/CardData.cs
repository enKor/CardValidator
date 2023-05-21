using CardValidator.Helpers;

namespace CardValidator.Configurations;

internal static class CardData
{
    internal static IReadOnlyDictionary<CardIssuer, CardInfo> BrandConfigurations => BrandsCfg;
    private static readonly Dictionary<CardIssuer, CardInfo> BrandsCfg = new();

    static CardData()
    {
        LoadAmericanExpress();
        LoadChinaUnionPay();
        LoadDankort();
        LoadDinersClub();
        LoadDiscover();
        LoadHipercard();
        LoadJcb();
        LoadLaser();
        LoadMaestro();
        LoadMasterCard();
        LoadRuPay();
        LoadSwitch();
        LoadUnknown();
        LoadVisa();
    }

    private static void LoadVisa()
    {
        BrandsCfg.Add(CardIssuer.Visa, new CardInfo
        {
            Configurations = new List<CardConfiguration>
            {
                new()
                {
                    Lengths = new List<int>(3) { 13, 16, 19 },
                    Prefixes = new List<string>(1) { "4" }
                }
            }
        });
    }

    private static void LoadMasterCard()
    {
        BrandsCfg.Add(CardIssuer.MasterCard, new CardInfo
        {
            Configurations = new List<CardConfiguration>
            {
                new()
                {
                    Lengths = new List<int>(3) { 13, 16, 19 },
                    Prefixes = new List<string>(1) { "4" }
                },
                new()
                {
                    Lengths = new List<int>(1) { 16 },
                    Prefixes = new List<string>()
                        .AddRange(51, 55)
                        .AddRange(2221, 2720)
                }
            }
        });
    }

    private static void LoadAmericanExpress()
    {
        BrandsCfg.Add(CardIssuer.AmericanExpress, new CardInfo
        {
            Configurations = new List<CardConfiguration>
            {
                new()
                {
                    Lengths = new List<int>(1) { 15 },
                    Prefixes = new List<string>(2) { "34", "37" }
                }
            }
        });
    }

    private static void LoadDinersClub()
    {
        BrandsCfg.Add(CardIssuer.DinersClub, new CardInfo
        {
            Configurations = new List<CardConfiguration>
            {
                new()
                {
                    Lengths = new List<int>(2) { 14, 16 },
                    Prefixes = new List<string>(9) { "3095", "36", "38" }
                        .AddRange(300, 305)
                }
            }
        });
    }

    private static void LoadDiscover()
    {
        BrandsCfg.Add(CardIssuer.Discover, new CardInfo
        {
            Configurations = new List<CardConfiguration>
            {
                new()
                {
                    Lengths = new List<int>(1) { 16 },
                    Prefixes = new List<string>(8) { "6011", "65" }
                        .AddRange(644, 649)
                }
            }
        });
    }

    private static void LoadJcb()
    {
        BrandsCfg.Add(CardIssuer.JCB, new CardInfo
        {
            Configurations = new List<CardConfiguration>
            {
                new()
                {
                    Lengths = new List<int>(2) { 15, 16 },
                    Prefixes = new List<string>(8) { "3528", "3529" }
                        .AddRange(353, 358)
                },
                new()
                {
                    Lengths = new List<int>(1) { 15 },
                    Prefixes = new List<string>(2) { "1800", "2131" }
                },
                new()
                {
                    Lengths = new List<int>(1) { 19 },
                    Prefixes = new List<string>(1) { "357266" }
                }
            }
        });
    }

    private static void LoadLaser()
    {
        BrandsCfg.Add(CardIssuer.Laser, new CardInfo
        {
            Configurations = new List<CardConfiguration>
            {
                new()
                {
                    Lengths = new List<int>(4) { 16, 17, 18, 19 },
                    Prefixes = new List<string>(1) { "6304" }
                }
            }
        });
    }

    private static void LoadSwitch()
    {
        BrandsCfg.Add(CardIssuer.Switch, new CardInfo
        {
            Configurations = new List<CardConfiguration>
            {
                new()
                {
                    Lengths = new List<int>(3) { 16, 18, 19 },
                    Prefixes = new List<string>(6) { "633110", "633312", "633304", "633303", "633301", "633300" }
                }
            }
        });
    }

    private static void LoadChinaUnionPay()
    {
        BrandsCfg.Add(CardIssuer.ChinaUnionPay, new CardInfo
        {
            SkipLuhn = true,
            Configurations = new List<CardConfiguration>
            {
                new()
                {
                    Lengths = new List<int>(4) { 16, 17, 18, 19 },
                    Prefixes = new List<string>(1) { "62" }
                }
            }
        });
    }

    private static void LoadDankort()
    {
        BrandsCfg.Add(CardIssuer.Dankort, new CardInfo
        {
            Configurations = new List<CardConfiguration>
            {
                new()
                {
                    Lengths = new List<int>(1) { 16 },
                    Prefixes = new List<string>(1) { "5019" }
                }
            }
        });
    }

    private static void LoadRuPay()
    {
        BrandsCfg.Add(CardIssuer.RuPay, new CardInfo
        {
            SkipLuhn = true,
            Configurations = new List<CardConfiguration>
            {
                new()
                {
                    Lengths = new List<int>(1) { 16 },
                    Prefixes = new List<string>(11) { "607", "608" }
                        .AddRange(6061, 6069)
                }
            }
        });
    }

    private static void LoadHipercard()
    {
        BrandsCfg.Add(CardIssuer.Hipercard, new CardInfo
        {
            Configurations = new List<CardConfiguration>
            {
                new()
                {
                    Lengths = new List<int>(1) { 19 },
                    Prefixes = new List<string>(1) { "384" }
                }
            }
        });
    }

    private static void LoadMaestro()
    {
        BrandsCfg.Add(CardIssuer.Maestro, new CardInfo
        {
            Configurations = new List<CardConfiguration>
            {
                new()
                {
                    Lengths = new List<int>(8) { 12, 13, 14, 15, 16, 17, 18, 19 },
                    Prefixes = new List<string>()
                        .AddRange(56, 58)
                        .AddRange(500, 500)
                        .AddRange(502, 509)
                        .AddRange(602, 605)
                        .AddRange(670, 679)
                        .AddRange(5010, 5018)
                        .AddRange(6000, 6060)
                        .AddRange(6760, 6769)
                }
            }
        });
    }

    private static void LoadUnknown()
    {
        BrandsCfg.Add(CardIssuer.Unknown, new CardInfo
        {
            Configurations = new List<CardConfiguration>
            {
                new()
                {
                    Lengths = new List<int>(1) { 15 },
                    Prefixes = new List<string>(3) { "7", "80", "90" }
                }
            }
        });
    }
}