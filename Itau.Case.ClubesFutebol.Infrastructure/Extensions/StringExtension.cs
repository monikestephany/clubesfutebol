using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Itau.Case.ClubesFutebol.Infrastructure.Extensions
{
    public static class StringExtension
    {
        public static string FormatString(this string value)
        {
            value = value.Replace("\t", "");
            value = value.RemoveAccentuation();
            value = value.Trim();
            return value;
        }
        public static string RemoveAccentuation(this string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
    }
}