using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skopia.Core.Entities
{
    public class Project
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid OwnerId { get; set; }
        public string Title { get; set; } = null!;
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }

}
