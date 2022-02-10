using MainApp.DataModels;
using MainApp.Repository.Interface;

namespace MainApp.Repository.Implements;

public class DepartmentRepository : Repository<Department>, IDepartmentRepository
{
    public DepartmentRepository(SystemContext context) : base(context)
    {
    }

    public override Task<int> InsertOrUpdate(Department model)
    {
        // Some Logic here 
        return base.InsertOrUpdate(model);
    }
}