using System.Text.RegularExpressions;

namespace ReporterDay.BusinessLayer.Utilities
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return string.Empty;

            // Küçük harfe çevir
            title = title.ToLowerInvariant().Trim();

            // Türkçe karakterleri düzleştir (isteğe bağlı)
            title = title
                .Replace("ç", "c").Replace("ğ", "g")
                .Replace("ı", "i").Replace("ö", "o")
                .Replace("ş", "s").Replace("ü", "u");

            // Özel karakterleri sil, boşlukları "-" yap
            title = Regex.Replace(title, @"[^a-z0-9\s-]", "");
            title = Regex.Replace(title, @"\s+", "-").Trim('-');

            return title;
        }
    }
}
