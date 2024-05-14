using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlowMindsApi.Models;

public class Category
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Parent_id { get; set; }
    public string Organization_id { get; set; }
}