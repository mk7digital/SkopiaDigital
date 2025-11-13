using MongoDB.Driver;
using Skopia.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skopia.Infrastructure.Persistence
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }

    public class MongoContext : IMongoContext
    {
        public IMongoDatabase Database { get; }

        public MongoContext(MongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            Database = client.GetDatabase(settings.Database);
        }
    }

}
