using Skopia.Core.Entities;
using Skopia.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skopia.Core.Services
{
    public interface ITaskService
    {
        Task<TaskItem> CreateAsync(string title, Guid projectId, CancellationToken cancellationToken = default);
        Task<TaskItem?> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TaskItem>> ListAsync(CancellationToken cancellationToken = default);
        Task<TaskItem?> UpdateStatusAsync(Guid id, TaskState newState, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }

}
