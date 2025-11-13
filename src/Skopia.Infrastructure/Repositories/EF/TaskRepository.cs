using Skopia.Core.Entities;
using Skopia.Core.Repositories;
using Skopia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skopia.Infrastructure.Repositories.EF
{
    public class TaskRepository : ITaskRepository
    {
        private readonly SkopiaContext _db;
        public TaskRepository(SkopiaContext db) => _db = db;

        public async Task AddAsync(TaskItem item, CancellationToken cancellationToken = default)
        {
            _db.Tasks.Add(item);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var e = await _db.Tasks.FindAsync(new object[] { id }, cancellationToken);
            if (e != null) { _db.Tasks.Remove(e); await _db.SaveChangesAsync(cancellationToken); }
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _db.Tasks.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<TaskItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _db.Tasks.FindAsync(new object[] { id }, cancellationToken);

        public async Task UpdateAsync(TaskItem item, CancellationToken cancellationToken = default)
        {
            _db.Tasks.Update(item);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }

}
