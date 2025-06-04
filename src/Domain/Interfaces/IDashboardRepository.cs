using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Domain.Interfaces;

public interface IDashboardRepository
{
    Task<bool> DeleteByDashboard();
    Task<bool> AddDashboard(ICollection<Dashboard> dashboard);
    Task<ICollection<Dashboard>> GetDashboardByStudentId(string studentId);
}
