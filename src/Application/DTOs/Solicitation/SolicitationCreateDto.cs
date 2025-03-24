namespace StudentCenterApi.src.Application.DTOs.Solicitation;

public class SolicitationCreateDto
{
    public int StudentId { get; set; }
    public string Description { get; set; }   
    public int RequestTypeId { get; set; }
}
