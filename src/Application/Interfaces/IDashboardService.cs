using StudentCenterApi.src.Application.DTOs.Solicitation;

namespace StudentCenterApi.src.Application.Interfaces;

public interface IDashboardService
{
    Task<SolicitationDashboardCreateDto> GetDashboardByStudentId(string studentId);
}
