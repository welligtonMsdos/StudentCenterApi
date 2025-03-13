using Microsoft.EntityFrameworkCore;
using StudentCenterApi.src.Domain.Model;
using StudentCenterApi.src.Infrastructure.Mapping;

namespace StudentCenterApi.src.Infrastructure.Data.Context;

public class StudentCenterContext : DbContext
{
    public StudentCenterContext(DbContextOptions<StudentCenterContext> options) : base(options)
    {
    }

    public DbSet<Status> Status { get; set; }
    public DbSet<StudentCenterBase> StudentCenterBase { get; set; }
    public DbSet<RequestType> RequestType { get; set; }
    public DbSet<Solicitation> Solicitation { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StatusMap());
        modelBuilder.ApplyConfiguration(new StudentCenterBaseMap());
        modelBuilder.ApplyConfiguration(new RequestTypeMap());
        modelBuilder.ApplyConfiguration(new SolicitationMap());

        modelBuilder.Entity<Solicitation>()
            .HasIndex(e => e.StudentId)
            .HasDatabaseName("IX_StudentId");

        modelBuilder.Entity<Solicitation>()
            .HasIndex(e => e.StatusId)
            .HasDatabaseName("IX_StatusId");
    }
}
