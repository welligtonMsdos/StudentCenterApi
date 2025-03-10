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

    public async Task<ICollection<Solicitation>> GetAll()
    {
        var solicitation = await _context.Solicitation
                             .Include(x => x.Status)
                             .Include(x => x.RequestType)
                             .AsNoTracking()
                             .OrderBy(x => x.Description)
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

    public async Task<Solicitation> Post(Solicitation entity)
    {
        entity.Active = true;

        _context.Solicitation.Add(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Solicitation> Put(Solicitation entity)
    {
        entity.Active = true;

        _context.Solicitation.Update(entity);

        await _context.SaveChangesAsync();

        return entity;
    }
}
