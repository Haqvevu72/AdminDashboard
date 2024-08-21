namespace AdminPanel.Entities;

public class Assaignment: BaseEntity , ISoftDelete
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime Deadline { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    
    // Foreign Key
    public int EmployeeId { get; set; }
    public int AdminId { get; set; }
    
    // Navigation Properties
    public User Admin { get; set; }
    public User Employee { get; set; }
}