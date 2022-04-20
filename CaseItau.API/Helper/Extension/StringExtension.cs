using System.Linq;

namespace CaseItau.API.Helper.Extension
{
    public static class StringExtension
    {
        public static string OnlyNumbers(this string text)
            => string.Concat(text.Where(char.IsDigit));

    }
}
