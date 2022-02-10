using MainApp.DataModels;

namespace MainApp.Repository.Interface;

public interface IRepository<TModel> where TModel : EntityBase
{
    Task<int> InsertOrUpdate (TModel model);
    Task<int> Remove(TModel model);
    Task<TModel?> GetById (Guid id);
    Task<IEnumerable<TModel>> GetAll();
}