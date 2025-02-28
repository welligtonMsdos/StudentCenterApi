using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCenterApi._1___Model;

namespace StudentCenterApi._2___Mapping;

public class StudentCenterBaseMap : IEntityTypeConfiguration<StudentCenterBase>
{
    public void Configure(EntityTypeBuilder<StudentCenterBase> builder)
    {
        builder.ToTable(nameof(StudentCenterBase));

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Description)
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder.Property(p => p.Active)
           .HasColumnType("bit")
           .IsRequired();

        builder.HasQueryFilter(p => p.Active);
    }
}
