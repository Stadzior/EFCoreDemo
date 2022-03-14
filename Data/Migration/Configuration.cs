using EFCoreDemo.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Data.Migration;

public static class Configuration
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Bar>()
            .HasData(
                new Bar { Id = 1, Name = "Bar1" }
            );
        modelBuilder
            .Entity<Foo>()
            .HasData(
                new Foo { Id = 1, Name = "Foo1", BarId = 1 },
                new Foo { Id = 2, Name = "Foo2", BarId = 1 }
            );
    }
}