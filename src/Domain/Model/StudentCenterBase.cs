namespace StudentCenterApi.src.Domain.Model;

public class StudentCenterBase
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public string Page { get; set; } = "";
    public bool Active { get; set; }
}
