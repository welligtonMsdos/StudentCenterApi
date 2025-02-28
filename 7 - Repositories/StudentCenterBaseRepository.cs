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
        return await Task.Run(() =>
        {
            _context.Remove(entity);

            var result = _context.SaveChanges();

            return result > 0 ? true : false;
        });
    }

    public async Task<ICollection<StudentCenterBase>> GetAll()
    {
        return await Task.Run(() =>
        {
            var status = _context.StudentCenterBase
                            .AsNoTracking()
                            .OrderBy(x => x.Description)
                            .ToListAsync();

            return status;
        });
    }

    public async Task<StudentCenterBase> GetById(int id)
    {
        return await Task.Run(() =>
        {
            var status = _context.StudentCenterBase
                            .AsNoTracking()
                            .FirstAsync(x => x.Id == id);

            return status;
        });
    }

    public Task<StudentCenterBase> Post(StudentCenterBase entity)
    {
        throw new NotImplementedException();
    }

    public Task<StudentCenterBase> Put(StudentCenterBase entity)
    {
        throw new NotImplementedException();
    }
}
