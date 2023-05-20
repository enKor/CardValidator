namespace CardValidator;

internal record CardConfiguration
{
    public List<int> Lengths { get; init; } = new();
    public List<string> Prefixes { get; init; } = new();
}