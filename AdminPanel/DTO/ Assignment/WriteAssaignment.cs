namespace AdminPanel.DTO.Task;

public class WriteAssaignment
{
    public string? Description { get; set; }
    public DateTime Deadline { get; set; }
    public int AdminId { get; set; }
    public int EmployeeId { get; set; }
}