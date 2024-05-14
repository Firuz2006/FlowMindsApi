using System.Text.Json.Serialization;

namespace FlowMindsApi.Models;

public class StackHolder : BaseEntity
{
    [JsonPropertyName("role_id")] public string RoleId { get; set; }

    [JsonPropertyName("review_time")] public int ReviewTime { get; set; }

    [JsonPropertyName("required")] public bool Required { get; set; }
}