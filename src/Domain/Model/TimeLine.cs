namespace StudentCenterApi.src.Domain.Model;

public class TimeLine
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string Month { get; set; }
    public string Solicitation { get; set; }
    public string Status { get; set; }
    public string StudentId { get; set; }
}
