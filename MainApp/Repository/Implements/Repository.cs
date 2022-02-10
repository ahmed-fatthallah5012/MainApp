using MainApp.DataModels;
using MainApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MainApp.Repository.Implements;

public abstract class Repository <TModel> : IRepository<TModel> where TModel : EntityBase
{
    protected readonly SystemContext _context;

    protected Repository(SystemContext context)
    {
        _context = context;
    }
    public virtual Task<int> InsertOrUpdate(TModel model)
    {
        _context.ChangeTracker.TrackGraph(model, node =>
        {
            var entry = node.Entry;
            var childEntry = (EntityBase) entry.Entity;
            entry.State = childEntry.IsNew ? EntityState.Added : EntityState.Modified;
        });
        return _context.SaveChangesAsync();
    }

    public virtual Task<int> Remove(TModel model)
    {
        _context.Remove(model);
        return _context.SaveChangesAsync();
    }

    public virtual async  Task<TModel?> GetById(Guid id) 
        => await _context.Set<TModel>().FindAsync(id);

    public virtual async Task<IEnumerable<TModel>> GetAll() 
        => await _context.Set<TModel>().ToListAsync();
}