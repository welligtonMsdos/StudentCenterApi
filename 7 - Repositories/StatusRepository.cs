using Microsoft.EntityFrameworkCore;
using StudentCenterApi._1___Model;
using StudentCenterApi._3___Context;
using StudentCenterApi._4___Interfaces.Repository;

namespace StudentCenterApi._7___Repositories;

public class StatusRepository : IStatusRepository
{
    private readonly StudentCenterContext _context;

    public StatusRepository(StudentCenterContext context)
    {
        _context = context;
    }
    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Status>> GetAll()
    {
        return await Task.Run(() =>
        {
            var status = _context.Status
                            .AsNoTracking()
                            .OrderBy(x => x.Description)
                            .ToListAsync();

            return status;
        });
    }

    public async Task<Status> GetById(int id)
    {
        return await Task.Run(() =>
        {
            var status = _context.Status
                            .AsNoTracking()
                            .FirstAsync(x => x.Id == id);

            return status;
        });
    }

    public Task<Status> Post(Status entity)
    {
        throw new NotImplementedException();
    }

    public Task<Status> Put(Status entity)
    {
        throw new NotImplementedException();
    }
}
