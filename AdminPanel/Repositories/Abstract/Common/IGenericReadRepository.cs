namespace AdminPanel.Repositories.Abstract;

public interface IGenericReadRepository<T>: IGenericRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
}