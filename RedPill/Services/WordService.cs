using RedPill.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RedPill.Services
{
    internal class WordService: IWordService
    {

        /// <summary>
        /// Reverses the specified string.
        /// </summary>
        /// <param name="input">The string to reverse.</param>
        /// <returns>The input string, reversed.</returns>
        /// <remarks>This method correctly reverses strings containing supplementary characters
        /// (which are encoded with two surrogate code units).</remarks>
        private string Reverse(char[] input)
        {
            //Copyright: http://code.logos.com/blog/2008/10/how_to_reverse_a_unicode_string_in_c.html
            // allocate a buffer to hold the output
            char[] output = new char[input.Length];
            for (int outputIndex = 0, inputIndex = input.Length - 1; outputIndex < input.Length; outputIndex++, inputIndex--)
            {
                // check for surrogate pair
                if (input[inputIndex] >= 0xDC00 && input[inputIndex] <= 0xDFFF &&
                    inputIndex > 0 && input[inputIndex - 1] >= 0xD800 && input[inputIndex - 1] <= 0xDBFF)
                {
                    // preserve the order of the surrogate pair code units
                    output[outputIndex + 1] = input[inputIndex];
                    output[outputIndex] = input[inputIndex - 1];
                    outputIndex++;
                    inputIndex--;
                }
                else
                {
                    output[outputIndex] = input[inputIndex];
                }
            }

            return new String(output);
        }

        public string ReverseWords(string s)
        {
            if (String.IsNullOrEmpty(s)) 
            {
                return String.Empty;
            }
            StringBuilder result = new StringBuilder(s.Length);
            var chars = s.ToCharArray();
            List<char> word = new List<char>();
            for (var i = 0; i < chars.Length; i++) {
                if (Char.IsWhiteSpace(chars[i]))
                {
                    if (word.Count > 0)
                    {
                        result.Append(this.Reverse(word.ToArray()));
                        word = new List<char>();
                    }
                    result.Append(chars[i]);
                }
                else
                {
                    word.Add(chars[i]);
                }
            }
            if (word.Count > 0)
            {
                result.Append(this.Reverse(word.ToArray()));
            }
            return result.ToString();
        }
    }
}