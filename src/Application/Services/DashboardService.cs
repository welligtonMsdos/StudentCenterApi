using AutoMapper;
using StudentCenterApi.src.Application.DTOs.Dashboard;
using StudentCenterApi.src.Application.DTOs.Solicitation;
using StudentCenterApi.src.Application.Interfaces;
using StudentCenterApi.src.Domain.Interfaces;
using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IMapper _mapper;

    private DashboardCreateDto dashboardCreateDto;

    public DashboardService(IServiceProvider serviceProvider, IMapper mapper)
    {
        _serviceProvider = serviceProvider;
        _mapper = mapper;
    }

    public async Task<bool> AddDashboard(ICollection<DashboardCreateDto> dashboardCreateDto)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dashboardRepository = scope.ServiceProvider.GetRequiredService<IDashboardRepository>();

            var dashboardList = _mapper.Map<ICollection<Dashboard>>(dashboardCreateDto);

            var result = await dashboardRepository.AddDashboard(dashboardList);
        }

        return true;
    }

    public async Task<bool> DeleteByDashboard()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dashboardRepository = scope.ServiceProvider.GetRequiredService<IDashboardRepository>();

            var result = await dashboardRepository.DeleteByDashboard();
        }

        return true;
    }

    public async Task<ICollection<DashboardCreateDto>> GetDashboard()
    {
        var listDashboard = new List<DashboardCreateDto>();

        using (var scope = _serviceProvider.CreateScope())
        {
            var solicitationRepository = scope.ServiceProvider.GetRequiredService<ISolicitationRepository>();

            var listStatus = await solicitationRepository.GetDashboardByStudentId();

            listStatus.ToList().ForEach(delegate (SolicitationDashboardDto item)
            {
                dashboardCreateDto = new DashboardCreateDto();
                
                dashboardCreateDto.LastUpdate = DateTime.Now.AddHours(-3);
                dashboardCreateDto.UserId = item.studentId;               
                dashboardCreateDto.CountCompleted = item.countCompleted;
                dashboardCreateDto.CountDenied = item.countDenied;
                dashboardCreateDto.CountPending = item.countPending;
                dashboardCreateDto.CountAll = item.countCompleted + item.countDenied + item.countPending;

                listDashboard.Add(dashboardCreateDto);
            });
        } 

        return listDashboard;
    }
}
