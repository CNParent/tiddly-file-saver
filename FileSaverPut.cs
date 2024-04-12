using System.Text.Json.Serialization;

public class FileSaverPut
{
    [JsonPropertyName("content")]
    public string Content { get; set; } = default!;
}
