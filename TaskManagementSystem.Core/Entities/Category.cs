using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Core.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AppTask> AppTasks { get; set; } = new List<AppTask>();
}
