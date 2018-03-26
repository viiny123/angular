using LivrariaContext.Shared.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Domain.Repository.Context
{
    public class MongoDBContext<T> where T : Entity
    {
        private readonly IMongoDatabase _database = null;

        public MongoDBContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<T> Table
        {
            get
            {
                return _database.GetCollection<T>(typeof(T).Name);
            }
        }
    }
}
