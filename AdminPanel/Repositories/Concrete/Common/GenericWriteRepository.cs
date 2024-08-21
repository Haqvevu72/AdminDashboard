using AdminPanel.Data;
using AdminPanel.Entities;
using AdminPanel.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Repositories.Concrete.Common;

public class GenericWriteRepository<T>: GenericRepository<T> , IGenericWriteRepository<T> where T: BaseEntity
{
    public GenericWriteRepository(AdminPanelDB context) : base(context)
    {
    }

    public async Task AddAsync(T entity)
    {
        await _table.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        _table.Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _table.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
            _table.Remove(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _table.Remove(entity);
    }

    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }
}