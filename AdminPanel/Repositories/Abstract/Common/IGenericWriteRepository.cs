using System.Threading.Tasks;

namespace AdminPanel.Repositories.Abstract;

public interface IGenericWriteRepository<T>: IGenericRepository<T>
{
    System.Threading.Tasks.Task AddAsync(T entity);
    System.Threading.Tasks.Task UpdateAsync(T entity);
    System.Threading.Tasks.Task DeleteAsync(int id);
    System.Threading.Tasks.Task DeleteAsync(T entity);
    System.Threading.Tasks.Task SaveChangeAsync();
}