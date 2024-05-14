namespace FlowMindsApi.Models;

public class Department : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ParentId { get; set; }
    public string OrganizationId { get; set; }
}