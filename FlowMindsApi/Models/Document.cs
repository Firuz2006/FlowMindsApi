using System.Text.Json.Serialization;

namespace FlowMindsApi.Models;

public class Document : BaseEntity
{
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("template_id")] public string TemplateId { get; set; }

    [JsonPropertyName("createdBy")] public string CreatedBy { get; set; }

    [JsonPropertyName("createdDate")] public string CreatedDate { get; set; }

    [JsonPropertyName("status")] public string Status { get; set; } // draft, active, reject, complete, discard

    [JsonPropertyName("content")] public string Content { get; set; }

    [JsonPropertyName("attachment")] public List<string> Attachment { get; set; }

    [JsonPropertyName("history")] public List<HistoryEntry> History { get; set; }

    [JsonPropertyName("fields")] public List<Field> Fields { get; set; }

    [JsonPropertyName("department_id")] public string DepartmentId { get; set; }

    [JsonPropertyName("category_id")] public string CategoryId { get; set; }

    [JsonPropertyName("flow")] public List<FlowStep> Flow { get; set; }
}

public class HistoryEntry
{
    [JsonPropertyName("action")] public string Action { get; set; } // reject, accept

    [JsonPropertyName("note")] public string Note { get; set; }

    [JsonPropertyName("userId")] public string UserId { get; set; }

    [JsonPropertyName("date")] public DateTime Date { get; set; }
}