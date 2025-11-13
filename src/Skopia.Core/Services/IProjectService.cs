using Skopia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skopia.Core.Services
{
    public interface IProjectService
    {
        Task<Project> CreateAsync(string name, CancellationToken cancellationToken = default);
        Task<Project?> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Project>> ListAsync(CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }

}
