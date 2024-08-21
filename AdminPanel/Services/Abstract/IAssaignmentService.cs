using AdminPanel.DTO.Task;

namespace AdminPanel.Services.Abstract;

public interface IAssaignmentService
{
    Task<ICollection<ReadAssaignment>> GetAllAssaignmentsAsync();
    Task<ReadAssaignment> GetAssaignmentByIdAsync(int assignmentId);
    Task<string> AddAssaignmentAsync(WriteAssaignment assignment);
    Task<string> UpdateAssaignmentAsync(int assaignmentId,WriteAssaignment assaignment);
    Task<string> DeleteAssaignmentAsync(int assaignmentId);
}