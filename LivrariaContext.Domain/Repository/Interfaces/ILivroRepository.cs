using LivrariaContext.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaContext.Domain.Repository.Interfaces
{
    public interface ILivroRepository :  IMongoRepository<Livro>
    {
        Task<bool> VerificarISBN(string ISBN);
    }
}
