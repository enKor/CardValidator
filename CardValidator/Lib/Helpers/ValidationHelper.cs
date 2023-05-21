namespace CardValidator.Helpers;

internal static class ValidationHelper
{
    internal static bool IsValidFormat(this ReadOnlySpan<char> input, out string? cleanCardNumber)
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
                cleanCardNumber = null;
                return false;
            }
        }

        cleanCardNumber = output[..outputIndex].ToString();
        return true;
    }
}