namespace StudentCenterApi.src.Application.DTOs.Solicitation;

public class SolicitationDashboardCreateDto
{
    public int CountAll { get; set; }
    public int CountCompleted { get; set; }
    public int CountDenied { get; set; }
    public int CountPending { get; set; }
}
