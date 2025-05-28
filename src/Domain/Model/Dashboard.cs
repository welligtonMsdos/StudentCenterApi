using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace StudentCenterApi.src.Domain.Model;

public class Dashboard
{
    [BsonId] // Mapeia o campo "_id" do MongoDB
    [BsonRepresentation(BsonType.ObjectId)]
    public string _id { get; set; }
    public int CountAll { get; set; }
    public int CountCompleted { get; set; }
    public int CountDenied { get; set; }
    public int CountPending { get; set; }
    public DateTime LastUpdate { get; set; }
    public string UserId { get; set; }
}
