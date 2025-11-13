using Skopia.Core.Entities;
using Skopia.Core.Repositories;
using Skopia.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skopia.Infrastructure.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repo;
        public ProjectService(IProjectRepository repo) => _repo = repo;

        public async Task<Project> CreateAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required", nameof(name));
            var p = new Project { Name = name };
            await _repo.AddAsync(p, cancellationToken);
            return p;
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default) =>
            _repo.DeleteAsync(id, cancellationToken);

        public Task<Project?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
            _repo.GetByIdAsync(id, cancellationToken);

        public Task<IEnumerable<Project>> ListAsync(CancellationToken cancellationToken = default) =>
            _repo.GetAllAsync(cancellationToken);
    }

}
