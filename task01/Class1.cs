using System;
namespace task01
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            string formatted = new([.. input.Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).Select(char.ToLower)]);
            return formatted.SequenceEqual(formatted.Reverse());
        }
    }
}
