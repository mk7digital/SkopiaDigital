using System;
using Skopia.Core.Enums;

namespace Skopia.Core.Entities
{
    public class TaskItem
    {
        // construtor padrão (permite object initializer)
        public TaskItem() { }

        // construtor compatível com chamadas que passam Priority
        public TaskItem(Priority priority)
        {
            Priority = priority;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public TaskState Status { get; set; } = TaskState.Pending;
        public Priority Priority { get; set; } = Priority.Normal;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }
        public Guid ProjectId { get; set; }
    }
}

