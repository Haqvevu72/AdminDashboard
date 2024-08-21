using AdminPanel.Data;
using AdminPanel.Entities;
using AdminPanel.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Repositories.Concrete.Common;

public class GenericRepository<T>: IGenericRepository<T> where T: BaseEntity
{
    protected readonly AdminPanelDB _context;
    protected DbSet<T> _table;

    public GenericRepository(AdminPanelDB context)
    {
        _context = context;
        _table = _context.Set<T>();
    }
}