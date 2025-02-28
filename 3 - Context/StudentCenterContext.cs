using Microsoft.EntityFrameworkCore;
using StudentCenterApi._1___Model;
using StudentCenterApi._2___Mapping;

namespace StudentCenterApi._3___Context;

public class StudentCenterContext: DbContext
{
    public StudentCenterContext(DbContextOptions<StudentCenterContext> options) : base(options)
    {            
    }

    public DbSet<Status> Status { get; set; }
    public DbSet<StudentCenterBase> StudentCenterBase { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StatusMap());
        modelBuilder.ApplyConfiguration(new StudentCenterBaseMap());
    }
}
