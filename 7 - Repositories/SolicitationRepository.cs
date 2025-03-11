using Microsoft.EntityFrameworkCore;
using StudentCenterApi._1___Model;
using StudentCenterApi._3___Context;
using StudentCenterApi._4___Interfaces.Repository;

namespace StudentCenterApi._7___Repositories;

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

    public async Task<Solicitation> GetById(int id)
    {
        var solicitation = await _context.Solicitation
                            .Include(x => x.Status)
                            .Include(x => x.RequestType)
                            .AsNoTracking()
                            .FirstAsync(x => x.Id == id);

        return solicitation;
    }

    public async Task<ICollection<Solicitation>> GetByStatusId(int statusId)
    {
        var solicitation = await _context.Solicitation
                            .Include(x => x.Status)
                            .Include(x => x.RequestType)
                            .AsNoTracking()
                            .Where(x => x.StatusId == statusId)
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
}
