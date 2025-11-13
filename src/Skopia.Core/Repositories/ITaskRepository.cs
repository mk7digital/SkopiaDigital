using Skopia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skopia.Core.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TaskItem>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(TaskItem item, CancellationToken cancellationToken = default);
        Task UpdateAsync(TaskItem item, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }

}
