using System;

namespace mPanel.Extra
{
    public static class StringExtensions
    {
        public static string InBetween(this string s, string start, string end)
        {
            if (string.IsNullOrWhiteSpace(start) || string.IsNullOrWhiteSpace(end))
                return string.Empty;

            var sIndex = s.IndexOf(start, StringComparison.Ordinal);
            var eIndex = s.IndexOf(end, StringComparison.Ordinal);
            var startLength = start.Length;

            return s.Substring(sIndex + startLength, eIndex - sIndex - startLength);
        }
    }
}
