using System.Text.Json.Serialization;

namespace Application.Contract
{
    public class MovieSearchFilter : PageRequest
    {
        public MovieSearchType SearchType { get; set; }
        public string? SearchValue { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))] // Serializes enum values as strings in JSON.
    public enum MovieSearchType
    {
        Title,
        Genre,
        Actor,
    }
}
