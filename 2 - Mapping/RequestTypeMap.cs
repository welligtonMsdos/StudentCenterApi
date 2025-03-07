using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCenterApi._1___Model;

namespace StudentCenterApi._2___Mapping;

public class RequestTypeMap : IEntityTypeConfiguration<RequestType>
{
    public void Configure(EntityTypeBuilder<RequestType> builder)
    {
        builder.ToTable(nameof(RequestType));

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Description)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(p => p.Active)
           .HasColumnType("bit")
           .IsRequired();

        builder.HasQueryFilter(p => p.Active);
    }
}
