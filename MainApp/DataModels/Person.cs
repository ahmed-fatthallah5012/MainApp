namespace MainApp.DataModels;

public class Person : EntityBase
{
    public string Name { get; set; } = "";
    public string? Phone { get; set; }
}