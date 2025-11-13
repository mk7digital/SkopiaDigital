using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skopia.Core.Entities
{
    public class Comment { 
        public Guid Id { get; private set; } = Guid.NewGuid(); 
        public Guid TaskId { get; set; } 
        public Guid AuthorId { get; set; } 
        public string Text { get; set; } = null!; 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
    }
}
