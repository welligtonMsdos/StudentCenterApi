namespace StudentCenterApi.src.Application.DTOs.Dashboard;

public class DashboardCreateDto
{
    public int CountAll { get; set; }
    public int CountCompleted { get; set; }
    public int CountDenied { get; set; }
    public int CountPending { get; set; }
    public DateTime LastUpdate { get; set; }
    public string UserId { get; set; }
}
