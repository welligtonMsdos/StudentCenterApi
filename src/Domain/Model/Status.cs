namespace StudentCenterApi.src.Domain.Model;

public class Status
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public bool Active { get; set; }
    public required ICollection<Solicitation> Solicitation { get; set; }
}
