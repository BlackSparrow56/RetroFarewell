namespace Utils.Extensions
{
    public static class StringExtension
    {
        public static string GetPart(this string str, float percent)
        {
            int count = (int) (str.Length * percent);
            return str.Substring(0, count);
        }
    }
}
    