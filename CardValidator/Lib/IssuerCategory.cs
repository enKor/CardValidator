using System.Collections.ObjectModel;

namespace CardValidator;

internal static class IssuerCategory
{
    internal static IReadOnlyDictionary<char, string> Identifiers { get; }

    static IssuerCategory()
    {
        var dic = new Dictionary<char, string>
        {
            { '0', "ISO/TC 68 and other future industry assignments" },
            { '1', "Airlines" },
            { '2', "Airlines and other future industry assignments" },
            { '3', "Travel and entertainment and banking/financial" },
            { '4', "Banking and financial" },
            { '5', "Banking and financial" },
            { '6', "Merchandising and banking/financial" },
            { '7', "Petroleum and other future industry assignments" },
            { '8', "Healthcare, telecommunications and other future industry assignments" },
            { '9', "National assignment" }
        };

        Identifiers = new ReadOnlyDictionary<char, string>(dic);
    }
}