namespace AdminPanel.DTO.Task;

public class ReadAssaignment
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public DateTime Deadline { get; set; }
    public string AdminInfo { get; set; }
    public string EmployeeInfo { get; set; }
}