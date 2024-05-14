using System.Text.Json.Serialization;

namespace FlowMindsApi.Models;

public class Role : BaseEntity
{
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("description")] public string Description { get; set; }

    [JsonPropertyName("department_id")] public string DepartmentId { get; set; }

    [JsonPropertyName("parent_id")] public string ParentId { get; set; }
}