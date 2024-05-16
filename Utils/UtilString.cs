namespace FindIt.Utils
{
    public class UtilString
    {
        public static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : string.Concat(value.AsSpan(0, maxLength), "...");
        }

        public static string ReadableDate(DateTime date)
        {
            return date.ToString("MMMM d, yyyy 'at' h:mm tt");
        }
    }
}