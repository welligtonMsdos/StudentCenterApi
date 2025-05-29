using StudentCenterApi.src.Application.Interfaces;
using StudentCenterApi.src.Application.Services;
using StudentCenterApi.src.Domain.Interfaces;
using StudentCenterApi.src.Infrastructure.Data.Repositories;

namespace StudentCenterApi.src.Infrastructure.Dependency_Injection;

public static class DependencyInjection
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IStatusRepository, StatusRepository>();
        services.AddScoped<IStatusService, StatusService>();

        services.AddScoped<IStudentCenterBaseRepository, StudentCenterBaseRepository>();
        services.AddScoped<IStudentCenterBaseService, StudentCenterBaseService>();

        services.AddScoped<IRequestTypeRepository, RequestTypeRepository>();
        services.AddScoped<IRequestTypeService, RequestTypeService>();

        services.AddScoped<ISolicitationRepository, SolicitationRepository>();
        services.AddScoped<ISolicitationService, SolicitationService>();

        services.AddScoped<ITimeLineRepository, TimeLineRepository>();
        services.AddScoped<ITimeLineService, TimeLineService>();

        services.AddScoped<IDashboardService, DashboardService>();

        return services;
    }
}
