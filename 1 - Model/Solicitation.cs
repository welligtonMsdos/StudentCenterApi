namespace StudentCenterApi._1___Model;

public class Solicitation
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string Description { get; set; }
    public int StatusId {  get; set; }
    public Status Status { get; set; }
    public int RequestTypeId {  get; set; }
    public RequestType RequestType { get; set; }
    public bool Active { get; set; }
}
