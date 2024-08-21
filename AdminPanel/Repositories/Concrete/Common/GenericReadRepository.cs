using AdminPanel.Data;
using AdminPanel.Entities;
using AdminPanel.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Repositories.Concrete.Common;

public class GenericReadRepository<T>: GenericRepository<T> , IGenericReadRepository<T> where T: BaseEntity
{
    public GenericReadRepository(AdminPanelDB context) : base(context)
    {
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return _table;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _table.FirstOrDefaultAsync(e => e.Id == id);
    }
}