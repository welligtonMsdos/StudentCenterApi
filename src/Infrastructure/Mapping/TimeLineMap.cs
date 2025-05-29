using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Infrastructure.Mapping;

public class TimeLineMap : IEntityTypeConfiguration<TimeLine>
{
    public void Configure(EntityTypeBuilder<TimeLine> builder)
    {
        builder.ToTable(nameof(TimeLine));

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Data)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(p => p.Month)
            .HasColumnType("varchar(3)")
            .IsRequired();

        builder.Property(p => p.Solicitation)
             .HasColumnType("varchar(300)")
             .IsRequired();

        builder.Property(p => p.Status)
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder.Property(p => p.StudentId)
            .HasColumnType("varchar(24)")
            .IsRequired();
    }
}
