namespace StudentCenterApi.src.Application.DTOs.Solicitation;

public class SolicitationDashboardDto
{
    public required string studentId { get; set; }
    public int countCompleted { get; set; }
    public int countPending { get; set; }
    public int countDenied { get; set; }
}