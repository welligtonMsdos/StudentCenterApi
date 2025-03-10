namespace StudentCenterApi._1___Model;

public class Status
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool Active { get; set; }
    public ICollection<Solicitation> Solicitation { get; set; }
}
