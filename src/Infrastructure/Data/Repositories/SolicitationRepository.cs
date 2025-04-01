using Microsoft.EntityFrameworkCore;
using StudentCenterApi.src.Domain.Interfaces;
using StudentCenterApi.src.Domain.Model;
using StudentCenterApi.src.Infrastructure.Data.Context;
using StudentCenterApi.src.Infrastructure.Enum;

namespace StudentCenterApi.src.Infrastructure.Data.Repositories;

public class SolicitationRepository : ISolicitationRepository
{
    private readonly StudentCenterContext _context;

    public SolicitationRepository(StudentCenterContext context)
    {
        _context = context;
    }

    public async Task<bool> Delete(Solicitation entity)
    {
        _context.Remove(entity);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<ICollection<Solicitation>> GetAllPendingStatuses()
    {
        var solicitation = await _context.Solicitation
                            .Include(x => x.Status)
                            .Include(x => x.RequestType)
                            .AsNoTracking()
                            .Where(x => x.StatusId == (int)EStatus.Pending)                            
                            .ToListAsync();

        return solicitation;
    }

    public async Task<Solicitation> GetById(int id)
    {
        var solicitation = await _context.Solicitation
                            .Include(x => x.Status)
                            .Include(x => x.RequestType)
                            .AsNoTracking()
                            .FirstAsync(x => x.Id == id);

        return solicitation;
    }

    public async Task<ICollection<Solicitation>> GetByStatusId(int statusId, int studentId)
    {
        if(statusId == 0) return await GetByStudentId(studentId);
        
        var solicitation = await _context.Solicitation
                            .Include(x => x.Status)
                            .Include(x => x.RequestType)
                            .AsNoTracking()
                            .Where(x => x.StatusId == statusId && 
                                   x.StudentId == studentId)
                            .OrderBy(x => x.Description)
                            .ToListAsync();

        return solicitation;
    }

    public async Task<ICollection<Solicitation>> GetByStudentId(int studentId)
    {
        var solicitation = await _context.Solicitation
                            .Include(x => x.Status)
                            .Include(x => x.RequestType)
                            .AsNoTracking()
                            .Where(x => x.StudentId == studentId)
                            .OrderBy(x => x.Description)
                            .ToListAsync();

        return solicitation;
    }

    public async Task<Solicitation> Post(Solicitation entity)
    {
        entity.Active = true;
        entity.StatusId = (int)EStatus.Pending;

        _context.Solicitation.Add(entity);

        await _context.SaveChangesAsync();

        await _context.Entry(entity)
                  .Reference(s => s.Status)
                  .LoadAsync();

        await _context.Entry(entity)
                  .Reference(s => s.RequestType)
                  .LoadAsync();

        return entity;
    }

    public async Task<Solicitation> Put(Solicitation entity)
    {
        entity.Active = true;

        _context.Solicitation.Update(entity);

        await _context.SaveChangesAsync();

        await _context.Entry(entity)
                  .Reference(s => s.Status)
                  .LoadAsync();

        await _context.Entry(entity)
                  .Reference(s => s.RequestType)
                  .LoadAsync();

        return entity;
    }

    public async Task<Solicitation> UpdateStatus(Solicitation entity)
    {
        _context.Solicitation.Attach(entity);

        _context.Entry(entity).Property(x => x.StatusId).IsModified = true;

        await _context.SaveChangesAsync();

        await _context.Entry(entity)
                  .Reference(s => s.Status)
                  .LoadAsync();

        await _context.Entry(entity)
                  .Reference(s => s.RequestType)
                  .LoadAsync();

        return entity;
    }
}
