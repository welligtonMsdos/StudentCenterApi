using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Infrastructure.Mapping;

public class StatusMap : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.ToTable(nameof(Status));

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
