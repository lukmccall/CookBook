using static System.String;

namespace CookBook.Extensions
{
    public static class String_Extension
    {

        public static string ToLowerFirstChar(this string input)
        {
            string newString = input;
            if (!IsNullOrEmpty(newString) && char.IsUpper(newString[0]))
            {
                newString = char.ToLower(newString[0]) + newString.Substring(1);
            }

            return newString;
        }

    }
}
