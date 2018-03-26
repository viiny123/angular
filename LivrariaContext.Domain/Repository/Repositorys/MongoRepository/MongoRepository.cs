using LivrariaContext.Domain.Repository.Context;
using LivrariaContext.Domain.Repository.Interfaces;
using LivrariaContext.Shared.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaContext.Domain.Repository.Repositorys.MongoRepository
{
    public abstract class MongoRepository<T> : IMongoRepository<T> where T : Entity
    {
        protected readonly MongoDBContext<T> _context = null;

        public MongoRepository(IOptions<Settings> settings)
        {
            _context = new MongoDBContext<T>(settings);
        }

        public async Task Add(T item)
        {
            await _context.Table.InsertOneAsync(item);
        }

        public async Task<T> Get(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _context.Table
                                 .Find(filter)
                                 .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Table.Find(_ => true).ToListAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
            return await _context.Table.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
        }

        public async Task<ReplaceOneResult> Update(T item)
        {
            return await _context.Table
                             .ReplaceOneAsync(s => s._id.Equals(item._id), item, new UpdateOptions { IsUpsert = true });
        }
    }
}
