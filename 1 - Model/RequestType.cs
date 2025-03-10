namespace StudentCenterApi._1___Model;

public class RequestType
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
    public ICollection<Solicitation> Solicitation { get; set; }
}
