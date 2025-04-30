using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Infrastructure.Mapping;

public class StudentCenterBaseMap : IEntityTypeConfiguration<StudentCenterBase>
{
    public void Configure(EntityTypeBuilder<StudentCenterBase> builder)
    {
        builder.ToTable(nameof(StudentCenterBase));

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Description)
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder.Property(p => p.Page)
            .HasColumnType("varchar(20)");

        //***SQLSERVER***
        //builder.Property(p => p.Active)
        //   .HasColumnType("bit")
        //   .IsRequired();
        //          

        builder.HasQueryFilter(p => p.Active);
    }
}
