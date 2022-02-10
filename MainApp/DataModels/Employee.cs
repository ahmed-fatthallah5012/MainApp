namespace MainApp.DataModels;

public class Employee : Person
{
    public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
}