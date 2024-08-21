using AdminPanel.Data;
using AdminPanel.Entities;
using AdminPanel.Repositories.Abstract.Task;
using AdminPanel.Repositories.Concrete.Common;

namespace AdminPanel.Repositories.Concrete.Assaignment;

public class AssaignmentWriteRepository: GenericWriteRepository<Entities.Assaignment> , IAssaignmentWriteRepository
{
    public AssaignmentWriteRepository(AdminPanelDB context) : base(context)
    {
    }
}