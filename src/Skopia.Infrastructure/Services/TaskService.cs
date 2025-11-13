using Skopia.Core.Entities;
using Skopia.Core.Enums;
using Skopia.Core.Repositories;
using Skopia.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skopia.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;
        public TaskService(ITaskRepository repo) => _repo = repo;

        public async Task<TaskItem> CreateAsync(string title, Guid projectId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title required", nameof(title));
            var item = new TaskItem(/* passe priority aqui */ Priority.Normal)
            {
                Title = title,
                ProjectId = projectId
            };
            await _repo.AddAsync(item, cancellationToken);
            return item;
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) =>
            _repo.DeleteAsync(id, cancellationToken);

        public Task<TaskItem?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            _repo.GetByIdAsync(id, cancellationToken);

        public Task<IEnumerable<TaskItem>> ListAsync(CancellationToken cancellationToken = default) =>
            _repo.GetAllAsync(cancellationToken);

        public async Task<TaskItem?> UpdateStatusAsync(Guid id, TaskState newState, CancellationToken cancellationToken = default)
        {
            var item = await _repo.GetByIdAsync(id, cancellationToken);
            if (item == null) return null;

            // regra simples: não voltar de Done para InProgress
            if (item.Status == TaskState.Done && newState == TaskState.InProgress)
                throw new InvalidOperationException("Cannot move from Done to InProgress");

            item.Status = newState;
            await _repo.UpdateAsync(item, cancellationToken);
            return item;
        }
    }

}
