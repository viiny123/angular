using LivrariaContext.Shared.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaContext.Domain.Repository.Interfaces
{
    public interface IMongoRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(string id);
        Task Add(T item);
        Task<DeleteResult> Remove(string id);
        Task<ReplaceOneResult> Update(T item);
    }
}
