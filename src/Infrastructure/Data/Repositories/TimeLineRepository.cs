using Microsoft.EntityFrameworkCore;
using StudentCenterApi.src.Domain.Interfaces;
using StudentCenterApi.src.Domain.Model;
using StudentCenterApi.src.Infrastructure.Data.Context;

namespace StudentCenterApi.src.Infrastructure.Data.Repositories;

public class TimeLineRepository : ITimeLineRepository
{
    private readonly StudentCenterContext _context;
    public TimeLineRepository(StudentCenterContext context)
    {
        _context = context;
    }

    public async Task<ICollection<TimeLine>> GetByStudentId(string studentId)
    {
        var timeline = await _context.TimeLine                            
                            .AsNoTracking()
                            .Where(x => x.StudentId == studentId)
                            .OrderByDescending(x => x.Data)
                            .ToListAsync();

        return timeline;
    }
}
