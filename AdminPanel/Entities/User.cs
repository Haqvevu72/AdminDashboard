using Microsoft.AspNetCore.Identity;

namespace AdminPanel.Entities;

public class User: IdentityUser<int> , ISoftDelete
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
     
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    // Navigation Property
    public ICollection<Assaignment> AdminTasks { get; set; }
    public ICollection<Assaignment> EmployeeTasks { get; set; }
}