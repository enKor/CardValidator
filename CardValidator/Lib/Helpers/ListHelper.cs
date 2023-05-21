namespace CardValidator.Helpers;

internal static class ListHelper
{
    internal static List<string> AddRange(this List<string> list, int start, int end)
    {
        for (int n = start; n <= end; n++)
        {
            list.Add(n.ToString());
        }

        return list;
    }
}