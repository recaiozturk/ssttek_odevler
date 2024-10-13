namespace LibraryManagementSystem.Service.Util
{
    public class UrlHelper
    {
        public static string ToUrlFriendly(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            input = input.ToLower();

            input = input.Replace(" ", "-").Replace(",", "-");

            input = input.Replace("ç", "c")
                         .Replace("ğ", "g")
                         .Replace("ı", "i")
                         .Replace("ö", "o")
                         .Replace("ş", "s")
                         .Replace("ü", "u");

            return input;
        }
    }
}
