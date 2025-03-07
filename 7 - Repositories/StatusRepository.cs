﻿using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> Delete(Status entity)
    {
        _context.Remove(entity);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<ICollection<Status>> GetAll()
    {
        var status = await _context.Status
                             .AsNoTracking()
                             .OrderBy(x => x.Description)
                             .ToListAsync();

        return status;
    }

    public async Task<Status> GetById(int id)
    {
        var status = await _context.Status
                            .AsNoTracking()
                            .FirstAsync(x => x.Id == id);

        return status;
    }

    public async Task<Status> Post(Status entity)
    {
        entity.Active = true;

        _context.Status.Add(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Status> Put(Status entity)
    {
        entity.Active = true;

        _context.Status.Update(entity);

        await _context.SaveChangesAsync();

        return entity;
    }
}
