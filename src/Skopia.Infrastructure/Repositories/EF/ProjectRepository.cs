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
    public class ProjectRepository : IProjectRepository
    {
        private readonly SkopiaContext _db;
        public ProjectRepository(SkopiaContext db) => _db = db;

        public async Task AddAsync(Project project, CancellationToken cancellationToken = default)
        {
            _db.Projects.Add(project);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var e = await _db.Projects.FindAsync(new object[] { id }, cancellationToken);
            if (e != null) { _db.Projects.Remove(e); await _db.SaveChangesAsync(cancellationToken); }
        }

        public async Task<IEnumerable<Project>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _db.Projects.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<Project?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _db.Projects.FindAsync(new object[] { id }, cancellationToken);

        public async Task UpdateAsync(Project project, CancellationToken cancellationToken = default)
        {
            _db.Projects.Update(project);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }

}
