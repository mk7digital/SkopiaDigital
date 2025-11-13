using MongoDB.Driver;
using Skopia.Core.Entities;
using Skopia.Core.Repositories;
using Skopia.Infrastructure.Persistence;

namespace Skopia.Infrastructure.Repositories.Mongo
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMongoCollection<TaskItem> _collection;

        public TaskRepository(IMongoContext context)
        {
            _collection = context.Database.GetCollection<TaskItem>("tasks");
        }

        public async Task AddAsync(TaskItem item, CancellationToken cancellationToken = default) =>
            await _collection.InsertOneAsync(item, null, cancellationToken);

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _collection.DeleteOneAsync(t => t.Id == id, cancellationToken);

        public async Task<IEnumerable<TaskItem>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await (await _collection.FindAsync(FilterDefinition<TaskItem>.Empty, cancellationToken: cancellationToken)).ToListAsync(cancellationToken);

        public async Task<TaskItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await (await _collection.FindAsync(t => t.Id == id, cancellationToken: cancellationToken)).FirstOrDefaultAsync(cancellationToken);

        public async Task UpdateAsync(TaskItem item, CancellationToken cancellationToken = default) =>
            await _collection.ReplaceOneAsync(t => t.Id == item.Id, item, new ReplaceOptions { IsUpsert = false }, cancellationToken);
    }
}

