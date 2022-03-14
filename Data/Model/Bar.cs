using System.Collections.Generic;

namespace EFCoreDemo.Data.Model;

public class Bar
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Foo> Foos { get; set; }
}