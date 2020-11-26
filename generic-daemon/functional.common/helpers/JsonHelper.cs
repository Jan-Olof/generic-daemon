using LanguageExt;
using System.Text.Json;

namespace functional.common.helpers
{
    public static class JsonHelper
    {
        public static JsonSerializerOptions CaseInsensitive() =>
             new()
             {
                 PropertyNameCaseInsensitive = true,
             };

        public static Option<T> Deserialize<T>(this string obj) where T : class =>
            JsonSerializer.Deserialize<T>(obj, CaseInsensitive()).ToOption();
    }
}