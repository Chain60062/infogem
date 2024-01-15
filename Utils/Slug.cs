
using System.Text.RegularExpressions;

namespace InfoGem.Utils;

public static class Slug{
    public static string ToSlug(this string text)
    {

        string str = AccentRemover.RemoveAccents(text).ToLower();
        // invalid chars           
        str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
        // convert multiple spaces into one space   
        str = Regex.Replace(str, @"\s+", " ").Trim();
        // cut and trim 
        str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
        
        str = Regex.Replace(str, @"\s", "-"); // hyphens   
        return str;
    }
}
