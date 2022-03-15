using System.Collections.Generic;

namespace EFCoreDemo.Data.Model;

public class Foo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Bar> Bars { get; set; }
}