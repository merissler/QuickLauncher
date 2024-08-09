using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickLauncher
{
    internal static class StringHelper
    {
        public static bool AnyWordStartsWith(string text, string query)
        {
            var substrings = new List<string>();

            // Trim the input to remove any leading or trailing whitespace
            text = text.Trim();

            // Split the input into words
            var words = text.Split(' ');

            // Generate substrings of all possible lengths
            for (int i = 0; i < words.Length; i++)
            {
                string substring = String.Empty;

                for (int j = i; j < words.Length; j++)
                {
                    if (j != i)
                    {
                        substring += ' ';
                    }

                    substring += words[j];
                }

                substrings.Add(substring);
            }

            foreach (string substring in substrings)
            {
                if (substring.ToLower().StartsWith(query.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
