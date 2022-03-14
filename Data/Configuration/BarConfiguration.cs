using EFCoreDemo.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Data.Configuration;

public class BarConfiguration : IEntityTypeConfiguration<Bar>
{
    public virtual void Configure(EntityTypeBuilder<Bar> builder)
    {
        builder.
            ToTable("Bar");

        builder
            .HasKey(bar => bar.Id);
        builder
            .HasKey(bar => bar.Id);

        builder
            .Property(bar => bar.Name)
            .HasMaxLength(50);
    }
}