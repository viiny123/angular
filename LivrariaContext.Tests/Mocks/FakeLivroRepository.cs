using LivrariaContext.Domain.Entities;
using LivrariaContext.Domain.Repository.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaContext.Tests.Mocks
{
    public class FakeLivroRepository : ILivroRepository
    {
        public Task Add(Livro item)
        {
            throw new NotImplementedException();
        }

        public Task<Livro> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Livro>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DeleteResult> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ReplaceOneResult> Update(Livro item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerificarISBN(string ISBN)
        {
            if (ISBN.Equals("1252658623641"))
                return true;
            else
                return false;
        }
    }
}
