namespace EFCoreDemo.Data.Model;

public class Foo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BarId { get; set; }
    public Bar Bar { get; set; }
}