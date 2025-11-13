using Skopia.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Skopia.Core.Entities
{
    public class TaskItem
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid ProjectId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Priority Priority { get; private set; }
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<TaskHistory> History { get; set; } = new List<TaskHistory>();

        public TaskItem(Priority priority) { Priority = priority; }
    }

}
