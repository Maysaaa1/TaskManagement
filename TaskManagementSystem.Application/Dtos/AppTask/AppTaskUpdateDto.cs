using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Dtos.AppTask;

public class AppTaskUpdateDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public int CategoryId { get; set; }
    public int PriorityId { get; set; }
    public string AssignedTo { get; set; } = null!;
    public bool IsCompleted { get; set; }
}
