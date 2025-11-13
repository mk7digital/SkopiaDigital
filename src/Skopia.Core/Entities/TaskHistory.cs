using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skopia.Core.Entities
{
    public class TaskHistory { 
        public Guid Id { get; private set; } = Guid.NewGuid(); 
        public Guid TaskId { get; set; } 
        public Guid ActorId { get; set; } 
        public string FieldChanged { get; set; } = null!; 
        public string? OldValue { get; set; } 
        public string? NewValue { get; set; } 
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow; 
    }
}
