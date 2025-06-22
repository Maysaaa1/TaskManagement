namespace TaskManagementSystem.Application.Dtos.AppTask;

public class AppTaskDto
{
    public int Id { get; set; }  
    public string Title { get; set; }
    public int CategoryId { get; set; }
    public int PriorityId { get; set; }
    public string AssignedTo { get; set; }  
    public string DueDate{ get; set;}
    public string Description { get; set; }

}
