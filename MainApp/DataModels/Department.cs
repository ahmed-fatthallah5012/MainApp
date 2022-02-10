namespace MainApp.DataModels;

public class Department : EntityBase
{
    public string? Name { get; set; }
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}