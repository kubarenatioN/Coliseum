namespace Kursach
{
    public static class StringHelpers
    {
        public static string SubstringOrFull(this string str, int len)
        {
            if (len > str.Length)
            {
                return str;
            }
            else
            {
                return str.Substring(0, len);
            }
        }
    }
}
