using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HealthTrainingWebsite.Utility
{
    public static class StringExtension
    {
        public static string RemoveHtmlTag(this string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public static string InsertNewLine(this string input)
        {
            return Regex.Replace(input, "<p>", Environment.NewLine + "<p>");
        }
        public static string GetUntilOrEmpty(this string text, string stopAt = "-")
        {
            if (!String.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                {
                    return text.Substring(0, charLocation);
                }
            }

            return String.Empty;
        }
    }
}
