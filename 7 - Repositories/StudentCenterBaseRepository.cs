using Microsoft.EntityFrameworkCore;
using StudentCenterApi._1___Model;
using StudentCenterApi._3___Context;
using StudentCenterApi._4___Interfaces.Repository;

namespace StudentCenterApi._7___Repositories;

public class StudentCenterBaseRepository : IStudentCenterBaseRepository
{
    private readonly StudentCenterContext _context;

    public StudentCenterBaseRepository(StudentCenterContext context)
    {
        _context = context;
    }

    public async Task<bool> Delete(StudentCenterBase entity)
    {
        _context.Remove(entity);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<ICollection<StudentCenterBase>> GetAll()
    {
        var studentCenter = await _context.StudentCenterBase
                            .AsNoTracking()
                            .OrderBy(x => x.Description)
                            .ToListAsync();

        return studentCenter;
    }

    public async Task<StudentCenterBase> GetById(int id)
    {
        var studentCenter = await _context.StudentCenterBase
                            .AsNoTracking()
                            .FirstAsync(x => x.Id == id);

        return studentCenter;
    }

    public async Task<StudentCenterBase> Post(StudentCenterBase entity)
    {
        entity.Active = true;

        _context.StudentCenterBase.Add(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<StudentCenterBase> Put(StudentCenterBase entity)
    {
        entity.Active = true;

        _context.StudentCenterBase.Update(entity);

        await _context.SaveChangesAsync();

        return entity;
    }
}
