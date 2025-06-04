using MongoDB.Driver;
using StudentCenterApi.src.Domain.Interfaces;
using StudentCenterApi.src.Domain.Model;
using StudentCenterApi.src.Infrastructure.Data.Context;

namespace StudentCenterApi.src.Infrastructure.Data.Repositories;

public class DashboardRepository : IDashboardRepository
{
    private readonly AuthContext _context;

    public DashboardRepository(AuthContext context)
    {
        _context = context;
    }

    public async Task<bool> AddDashboard(ICollection<Dashboard> dashboard)
    {
        await _context.Dashboards.InsertManyAsync(dashboard);

        return true;
    }

    public async Task<bool> DeleteByDashboard()
    {
        var result = await _context.Dashboards.DeleteManyAsync(Builders<Dashboard>.Filter.Exists("_id"));

        return true;
    }

    public async Task<ICollection<Dashboard>> GetDashboardByStudentId(string studentId)
    {
        var dashboards = await _context.Dashboards
            .Find(d => d.UserId == studentId)
            .ToListAsync();

        return dashboards;
    }
}
