namespace Merchello.UkFest.Web
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;

    using Umbraco.Core;

    /// <summary>
    /// The string extensions.
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Replaces \ with / in a path.
        /// </summary>
        /// <param name="value">
        /// The value to replace backslashes.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string EnsureForwardSlashes(this string value)
        {
            return value.Replace("\\", "/");
        }

        /// <summary>
        /// Replaces \ with / in a path.
        /// </summary>
        /// <param name="value">
        /// The value to replace forward slashes.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string EnsureBackSlashes(this string value)
        {
            return value.Replace("/", "\\");
        }

        /// <summary>
        /// Ensures a string both starts and ends with a character.
        /// </summary>
        /// <param name="input">
        /// The input string.
        /// </param>
        /// <param name="value">
        /// The char value to assert
        /// </param>
        /// <returns>
        /// The asserted string.
        /// </returns>
        public static string EnsureStartsAndEndsWith(this string input, char value)
        {
            return input.EnsureStartsWith(value).EnsureEndsWith(value);
        }

        /// <summary>
        /// Ensures a string does not end with a character.
        /// </summary>
        /// <param name="input">
        /// The input string.
        /// </param>
        /// <param name="value">
        /// The char value to assert
        /// </param>
        /// <returns>
        /// The asserted string.
        /// </returns>
        public static string EnsureNotEndsWith(this string input, char value)
        {
            return !input.EndsWith(value.ToString(CultureInfo.InvariantCulture)) ? input :
                input.Remove(input.LastIndexOf(value), 1);
        }

        /// <summary>
        /// Ensures a string does not start with a character.
        /// </summary>
        /// <param name="input">
        /// The input string.
        /// </param>
        /// <param name="value">
        /// The char value to assert
        /// </param>
        /// <returns>
        /// The asserted string.
        /// </returns>
        public static string EnsureNotStartsWith(this string input, char value)
        {
            return !input.StartsWith(value.ToString(CultureInfo.InstalledUICulture)) ? input : input.Remove(0, 1);
        }

        /// <summary>
        /// Ensures a string does not start or end with a character.
        /// </summary>
        /// <param name="input">
        /// The input string.
        /// </param>
        /// <param name="value">
        /// The char value to assert
        /// </param>
        /// <returns>
        /// The asserted string.
        /// </returns>
        public static string EnsureNotStartsOrEndsWith(this string input, char value)
        {
            return input.EnsureNotStartsWith(value).EnsureNotEndsWith(value);
        }

        /// <summary>
        /// Asserts the first character in the string is lowercase.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string FirstCharToLowerCase(this string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            return char.ToLowerInvariant(value[0]) + value.Substring(1);
        }

        /// <summary>
        /// The convert to slug.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        internal static string ConvertToSlug(string value)
        {
            return RemoveSpecialCharacters(value).SafeEncodeUrlSegments().Replace("--", "-").ToLowerInvariant().EnsureNotStartsOrEndsWith('/');
        }

        /// <summary>
        /// Encodes url segments.
        /// </summary>
        /// <param name="urlPath">
        /// The url path.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <seealso cref="https://github.com/Shandem/Articulate/blob/master/Articulate/StringExtensions.cs"/>
        private static string SafeEncodeUrlSegments(this string urlPath)
        {
            return string.Join(
                "/",
                urlPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x =>
                    {
                        var urlEncode = HttpUtility.UrlEncode(x);
                        return urlEncode != null ? urlEncode.Replace("+", "-") : null;
                    })
                    .WhereNotNull()

                    //// we are not supporting dots in our URLs it's just too difficult to
                //// support across the board with all the different config options
                    .Select(x => x.Replace('.', '-')));
        }

        /// <summary>
        /// The remove special characters.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string RemoveSpecialCharacters(string input)
        {
            var regex = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return regex.Replace(input, string.Empty);
        }


        /// <summary>
        /// Syntactic sugar for !string.IsNullOrEmpty
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this object input)
        {
            return input != null && !string.IsNullOrEmpty(input.ToString());
        }

        /// <summary>
        /// Syntactic sugar for !string.IsNullOrWhiteSpace
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNotNullOrWhiteSpace(this object input)
        {
            return input != null && !string.IsNullOrWhiteSpace(input.ToString());
        }

        /// <summary>
        /// Replaces newline characters with the supplied string
        /// Useful when stringifying content from richtext and multilinee textbox editors
        /// </summary>
        /// <param name="input"></param>
        /// <param name="replacementString"></param>
        /// <returns></returns>
        public static string ReplaceNewLines(this string input, string replacementString)
        {
            return Regex.Replace(input, @"\r\n?|\n", replacementString);
        }

        /// <summary>
        /// Truncates the provided string to the passed number of characters.
        /// Will not chop a word in half, if possible.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string TruncateAtWord(this string input, int length)
        {

            if (input == null || input.Length < length || input.IndexOf(" ", length, System.StringComparison.Ordinal) == -1)
                return input;

            // Little hack as the HtmlString from the RTE is URL Encoded.
            var result = input.Replace("&amp;", "&");

            return result.Substring(0, result.IndexOf(" ", length, System.StringComparison.Ordinal));
        }
    }
}