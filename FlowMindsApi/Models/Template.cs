using System.Text.Json.Serialization;

namespace FlowMindsApi.Models;

using System.Collections.Generic;

public class Template : BaseEntity
{
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("description")] public string Description { get; set; }

    [JsonPropertyName("content")] public string Content { get; set; }

    [JsonPropertyName("attachment")] public string Attachment { get; set; }

    [JsonPropertyName("fields")] public List<Field> Fields { get; set; }

    [JsonPropertyName("department_id")] public string DepartmentId { get; set; }

    [JsonPropertyName("category_id")] public string CategoryId { get; set; }

    [JsonPropertyName("flow")] public List<FlowStep> Flow { get; set; }
}