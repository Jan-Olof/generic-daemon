using LaYumba.Functional;
using System.Text.Json;

namespace classic.common.helpers
{
    public static class JsonHelper
    {
        public static JsonSerializerOptions CaseInsensitive() =>
             new JsonSerializerOptions
             {
                 PropertyNameCaseInsensitive = true,
             };

        public static Option<T> Deserialize<T>(this string obj) where T : class =>
            JsonSerializer.Deserialize<T>(obj, CaseInsensitive()).ToOption();
    }
}