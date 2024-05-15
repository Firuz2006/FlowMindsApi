using System.Text.Json.Serialization;

namespace FlowMindsApi.Models;

public class Department : BaseEntity
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
    [JsonPropertyName("parent_id")] public string ParentId { get; set; }
    [JsonPropertyName("organization_id")] public string OrganizationId { get; set; }
}