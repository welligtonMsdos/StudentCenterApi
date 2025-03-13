using Microsoft.EntityFrameworkCore;
using StudentCenterApi.src.Domain.Interfaces;
using StudentCenterApi.src.Domain.Model;
using StudentCenterApi.src.Infrastructure.Data.Context;

namespace StudentCenterApi.src.Infrastructure.Data.Repositories;

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
