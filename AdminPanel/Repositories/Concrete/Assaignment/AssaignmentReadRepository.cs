using AdminPanel.Data;
using AdminPanel.DTO.Task;
using AdminPanel.Entities;
using AdminPanel.Repositories.Abstract.Task;
using AdminPanel.Repositories.Concrete.Common;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Repositories.Concrete.Assaignment;

public class AssaignmentReadRepository: GenericReadRepository<Entities.Assaignment> , IAssignmentReadRepository
{
    private readonly AdminPanelDB _context;
    public AssaignmentReadRepository(AdminPanelDB context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<Entities.Assaignment>> GetAllWithAdminAsync()
    {
        return await _context.Assaignments.Include(a => a.Admin).
            Include(a => a.Employee).ToListAsync();
    }

    public async Task<Entities.Assaignment> GetByIdWithAdminAsync(int Id)
    {
        return await _context.Assaignments.Include(a => a.Admin)
            .Include(a => a.Employee).FirstOrDefaultAsync(a => a.Id == Id);
    }
}