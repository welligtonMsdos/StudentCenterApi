using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCenterApi.src.Domain.Model;

namespace StudentCenterApi.src.Infrastructure.Mapping;

public class SolicitationMap : IEntityTypeConfiguration<Solicitation>
{
    public void Configure(EntityTypeBuilder<Solicitation> builder)
    {
        builder.ToTable(nameof(Solicitation));

        builder.HasKey(x => x.Id);

        builder.Property(p => p.StudentId)
            .HasColumnType("varchar(24)")           
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnType("varchar(300)")
            .IsRequired();

        builder.Property(p => p.Active)
           .HasColumnType("bit")
           .IsRequired();

        builder.HasQueryFilter(p => p.Active);

        builder.HasOne(p => p.Status)
            .WithMany(p => p.Solicitation)
            .HasForeignKey(p => p.StatusId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.RequestType)
            .WithMany(p => p.Solicitation)
            .HasForeignKey(p => p.RequestTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
