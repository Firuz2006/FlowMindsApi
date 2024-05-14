using System.Text.Json.Serialization;

namespace FlowMindsApi.Models;

public class FlowStep : BaseEntity
{
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("order")] public string Order { get; set; }

    [JsonPropertyName("minimum_approvement")]
    public int MinimumApprovement { get; set; }

    [JsonPropertyName("stack_holders")] public List<StackHolder> StackHolders { get; set; }
}