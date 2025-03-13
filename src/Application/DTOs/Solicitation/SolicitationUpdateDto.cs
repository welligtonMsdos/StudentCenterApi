namespace StudentCenterApi.src.Application.DTOs.Solicitation;

public class SolicitationUpdateDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string Description { get; set; }
    public int StatusId { get; set; }
    public int RequestTypeId { get; set; }
}
