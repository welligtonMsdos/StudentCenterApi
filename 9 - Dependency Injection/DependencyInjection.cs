using StudentCenterApi._4___Interfaces.Repository;
using StudentCenterApi._4___Interfaces.Services;
using StudentCenterApi._7___Repositories;
using StudentCenterApi._8___Services;

namespace StudentCenterApi._9___Dependency_Injection;

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

        return services;
    }
}
