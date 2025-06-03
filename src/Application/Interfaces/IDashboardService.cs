using StudentCenterApi.src.Application.DTOs.Dashboard;

namespace StudentCenterApi.src.Application.Interfaces;

public interface IDashboardService
{
    Task<ICollection<DashboardCreateDto>> GetDashboard();
    Task<bool> DeleteByDashboard();
    Task<bool> AddDashboard(ICollection<DashboardCreateDto> dashboardCreateDto);
}
