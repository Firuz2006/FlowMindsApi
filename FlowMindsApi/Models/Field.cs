using System.Text.Json.Serialization;

namespace FlowMindsApi.Models;

public class Field : BaseEntity
{
    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("default")] public string Default { get; set; }

    [JsonPropertyName("values")] public List<string> Values { get; set; }

    [JsonPropertyName("role_id")] public string RoleId { get; set; }
}