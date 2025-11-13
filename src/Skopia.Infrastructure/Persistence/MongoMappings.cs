using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using Skopia.Core.Entities;

namespace Skopia.Infrastructure.Persistence
{
    public static class MongoMappings
    {
        public static void Register()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Project)))
            {
                BsonClassMap.RegisterClassMap<Project>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdProperty(p => p.Id).SetIdGenerator(GuidGenerator.Instance);
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(TaskItem)))
            {
                BsonClassMap.RegisterClassMap<TaskItem>(cm =>
                {
                    cm.AutoMap();
                    cm.MapIdProperty(t => t.Id).SetIdGenerator(GuidGenerator.Instance);
                });
            }
        }
    }
}

