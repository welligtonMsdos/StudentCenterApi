using StudentCenterApi.src.Application.DTOs.Solicitation;
using StudentCenterApi.src.Application.Interfaces;
using StudentCenterApi.src.Domain.Interfaces;

namespace StudentCenterApi.src.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IServiceProvider _serviceProvider;

    private SolicitationDashboardCreateDto dashboardCreateDto;

    public DashboardService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        dashboardCreateDto = new SolicitationDashboardCreateDto();
    }

    public async Task<SolicitationDashboardCreateDto> GetDashboardByStudentId(string studentId)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var solicitationRepository = scope.ServiceProvider.GetRequiredService<ISolicitationRepository>();

            var listStatus = await solicitationRepository.GetDashboardByStudentId(studentId);

            listStatus.ToList().ForEach(delegate (SolicitationDashboardDto item) {
                switch (item.statusId)
                {
                    case 1: dashboardCreateDto.CountPending = item.count; break;
                    case 2: dashboardCreateDto.CountDenied = item.count; break;
                    default: dashboardCreateDto.CountCompleted = item.count; break;
                }
            });
        } 

        return dashboardCreateDto;
    }
}
