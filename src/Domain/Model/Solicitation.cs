using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace StudentCenterApi.src.Domain.Model;

public class Solicitation
{
    public int Id { get; set; }   
    public string StudentId { get; set; }
    public required string Description { get; set; }
    public int StatusId { get; set; }
    public required Status Status { get; set; }
    public int RequestTypeId { get; set; }
    public required RequestType RequestType { get; set; }
    public bool Active { get; set; }
}
