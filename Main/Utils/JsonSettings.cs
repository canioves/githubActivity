using System.Text.Json;
using System.Text.Json.Serialization;

namespace Main.Utils
{
    public static class JsonSettings
    {
        public static readonly JsonSerializerOptions Default = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
        };
    }
}
