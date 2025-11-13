using MongoDB.Driver;
using Skopia.Core.Entities;
using Skopia.Core.Repositories;
using Skopia.Infrastructure.Persistence;

namespace Skopia.Infrastructure.Repositories.Mongo
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IMongoCollection<Project> _collection;

        public ProjectRepository(IMongoContext context)
        {
            _collection = context.Database.GetCollection<Project>("projects");
        }

        public async Task AddAsync(Project project, CancellationToken cancellationToken = default) =>
            await _collection.InsertOneAsync(project, null, cancellationToken);

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _collection.DeleteOneAsync(p => p.Id == id, cancellationToken);

        public async Task<IEnumerable<Project>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await (await _collection.FindAsync(FilterDefinition<Project>.Empty, cancellationToken: cancellationToken)).ToListAsync(cancellationToken);

        public async Task<Project?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await (await _collection.FindAsync(p => p.Id == id, cancellationToken: cancellationToken)).FirstOrDefaultAsync(cancellationToken);

        public async Task UpdateAsync(Project project, CancellationToken cancellationToken = default) =>
            await _collection.ReplaceOneAsync(p => p.Id == project.Id, project, new ReplaceOptions { IsUpsert = false }, cancellationToken);
    }
}

