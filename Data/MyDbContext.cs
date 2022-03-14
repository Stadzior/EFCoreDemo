using EFCoreDemo.Data.Configuration;
using EFCoreDemo.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Data;

public class MyDbContext : DbContext
{
    public virtual DbSet<Foo> Foos { get; set; }
    public virtual DbSet<Bar> Bars { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new FooConfiguration().Configure(modelBuilder.Entity<Foo>());
        new BarConfiguration().Configure(modelBuilder.Entity<Bar>());
        Migration.Configuration.Seed(modelBuilder);
    }
}