using EFCoreDemo.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Data.Migration;

public static class Configuration
{
    public static void Seed(MyDbContext context)
    {
        var bar1 = new Bar { Name = "Bar1" };
        var bar2 = new Bar { Name = "Bar2" };
        var bar3 = new Bar { Name = "Bar3" };
        var bar4 = new Bar { Name = "Bar4" };

        var foo1 = new Foo
        {
            Name = "Foo1",
            Bars = new[] { bar1, bar2 }
        };
        var foo2 = new Foo
        {
            Name = "Foo2",
            Bars = new[] { bar3, bar4 }
        };

        context.Foos.Update(foo1);
        context.Foos.Update(foo2);

        context.SaveChanges();
    }
}