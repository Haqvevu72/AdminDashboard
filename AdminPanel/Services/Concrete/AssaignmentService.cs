using AdminPanel.DTO.Task;
using AdminPanel.Entities;
using AdminPanel.Repositories.Abstract.Task;
using AdminPanel.Repositories.Abstract.User;
using AdminPanel.Services.Abstract;

namespace AdminPanel.Services.Concrete;

public class AssaignmentService: IAssaignmentService
{
    private readonly IAssignmentReadRepository _assignmentReadRepository;
    private readonly IAssaignmentWriteRepository _assaignmentWriteRepository;

    public AssaignmentService(IAssignmentReadRepository assignmentReadRepository, IAssaignmentWriteRepository assaignmentWriteRepository)
    {
        _assignmentReadRepository = assignmentReadRepository;
        _assaignmentWriteRepository = assaignmentWriteRepository;
    }

    public async Task<ICollection<ReadAssaignment>> GetAllAssaignmentsAsync()
    {
        var request = await _assignmentReadRepository.GetAllWithAdminAsync();

        var ReadAssaignmentList = request.Select(a => new ReadAssaignment()
        {
            Id = a.Id,
            Description = a.Description,
            Deadline = a.Deadline,
            AdminInfo = a.Admin.Firstname + " " + a.Admin.Lastname,
            EmployeeInfo = a.Employee.Firstname + " " + a.Employee.Lastname
        }).ToList();

        return ReadAssaignmentList;
    }

    public async Task<ReadAssaignment> GetAssaignmentByIdAsync(int assignmentId)
    {
        var request = await _assignmentReadRepository.GetByIdWithAdminAsync(assignmentId);

        if (request is not null)
        { var result = new ReadAssaignment()
            {
                Id = request.Id,
                Deadline = request.Deadline,
                Description = request.Description,
                AdminInfo = request.Admin.Firstname + " " + request.Admin.Lastname,
                EmployeeInfo = request.Employee.Firstname + " " + request.Employee.Lastname
            };

            return result;
        }

        return null;
    }

    public async Task<string> AddAssaignmentAsync(WriteAssaignment assignment)
    {
        Assaignment newAssaignment = new Assaignment()
        {
            Description = assignment.Description,
            Deadline = assignment.Deadline,
            AdminId = assignment.AdminId,
            EmployeeId = assignment.EmployeeId
        };

        await _assaignmentWriteRepository.AddAsync(newAssaignment);
        await _assaignmentWriteRepository.SaveChangeAsync();

        return "Assaignment has added successfully";
    }

    public async Task<string> UpdateAssaignmentAsync(int assaignmentId, WriteAssaignment assaignment)
    {
        var request = await _assignmentReadRepository.GetByIdAsync(assaignmentId);

        if (request is null)
            return "Sorry! Assaignment was not found .";

        if (request.Description != assaignment.Description)
            request.Description = assaignment.Description;
        
        if (request.Deadline != assaignment.Deadline)
            request.Deadline = assaignment.Deadline;

        if (request.AdminId != assaignment.AdminId)
            request.AdminId = assaignment.AdminId;

        if (request.EmployeeId != assaignment.EmployeeId)
            request.EmployeeId = assaignment.EmployeeId;

        await _assaignmentWriteRepository.UpdateAsync(request);
        await _assaignmentWriteRepository.SaveChangeAsync();

        return "Assaignment is updated successfully .";
    }

    public async Task<string> DeleteAssaignmentAsync(int assaignmentId)
    {
        var assaignment = await _assignmentReadRepository.GetByIdAsync(assaignmentId);
        if( assaignment is null)
            return "Sorry! Assaignment was not found .";

        await _assaignmentWriteRepository.DeleteAsync(assaignment);
        await _assaignmentWriteRepository.SaveChangeAsync();

        return "Assaignment has removed successfully .";
    }
}