namespace StudentCenterApi.src.Domain.Model;

public class RequestType
{
    public int Id { get; set; }    
    public required string Description { get; set; } 
    public bool Active { get; set; }    
    public ICollection<Solicitation>? Solicitation { get; set; }
}
