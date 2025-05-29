using StudentCenterApi.src.Application.Interfaces;

namespace StudentCenterApi.src.Application.Services;

public class DashboardBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public DashboardBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }    

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dashboardService = scope.ServiceProvider.GetRequiredService<IDashboardService>();

                await dashboardService.GetDashboardByStudentId("67f42b4a406f3f471ac3ebcf");
            }

            await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
        }
    }
}
