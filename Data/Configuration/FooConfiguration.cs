using EFCoreDemo.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Data.Configuration;

public class FooConfiguration : IEntityTypeConfiguration<Foo>
{
    public virtual void Configure(EntityTypeBuilder<Foo> builder)
    {
        builder
            .ToTable("Foo");

        builder
            .HasKey(foo => foo.Id);

        builder
            .Property(foo => foo.Name)
            .HasMaxLength(50);

        builder
            .HasOne(foo => foo.Bar)
            .WithMany(bar => bar.Foos)
            .IsRequired()
            .HasForeignKey(foo => foo.BarId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}