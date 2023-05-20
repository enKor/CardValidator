namespace CardValidator;

internal static class ListHelper
{
    internal static List<string> AddRange(this List<string> list, int start, int end)
    {
        for (int i = 0, n = start; n <= end; n++, i++)
        {
            list.Add(n.ToString());
        }

        return list;
    }
}