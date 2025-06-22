using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Core.Entities;

public partial class AppTask
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    public bool? IsCompleted { get; set; }

    public int? CategoryId { get; set; }

    public int? PriorityId { get; set; }

    public string? CreatedBy { get; set; }

    public string? AssignedTo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Priority? Priority { get; set; }
}

