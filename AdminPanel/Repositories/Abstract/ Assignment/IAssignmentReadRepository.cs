namespace AdminPanel.Repositories.Abstract.Task;

public interface IAssignmentReadRepository: IGenericReadRepository<Entities.Assaignment>
{
    public Task<ICollection<Entities.Assaignment>> GetAllWithAdminAsync();
    public Task<Entities.Assaignment> GetByIdWithAdminAsync(int Id);
}