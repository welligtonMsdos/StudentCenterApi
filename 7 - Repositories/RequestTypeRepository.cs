using Microsoft.EntityFrameworkCore;
using StudentCenterApi._1___Model;
using StudentCenterApi._3___Context;
using StudentCenterApi._4___Interfaces.Repository;

namespace StudentCenterApi._7___Repositories;

public class RequestTypeRepository : IRequestTypeRepository
{
    private readonly StudentCenterContext _context;

    public RequestTypeRepository(StudentCenterContext context)
    {
        _context = context;
    }

    public async Task<bool> Delete(RequestType entity)
    {
        _context.Remove(entity);

        var result = await _context.SaveChangesAsync(); 

        return result > 0;
    }

    public async Task<ICollection<RequestType>> GetAll()
    {
        var requestType = await _context.RequestType
                                .AsNoTracking()
                                .OrderBy(x => x.Description)
                                .ToListAsync();

        return requestType;
    }

    public async Task<RequestType> GetById(int id)
    {
        var requestType = await _context.RequestType
                                   .AsNoTracking()
                                   .FirstAsync(x => x.Id == id);

        return requestType;
    }

    public async Task<RequestType> Post(RequestType entity)
    {
        entity.Active = true;

        _context.RequestType.Add(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<RequestType> Put(RequestType entity)
    {
        entity.Active = true;

        _context.RequestType.Update(entity);

        await _context.SaveChangesAsync();

        return entity;
    }
}
