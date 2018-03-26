using LivrariaContext.Domain.Entities;
using LivrariaContext.Domain.Repository.Context;
using LivrariaContext.Domain.Repository.Interfaces;
using LivrariaContext.Domain.Repository.Repositorys.MongoRepository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaContext.Domain.Repository.Repositorys.LivroRepository
{
    public class LivroRepository : MongoRepository<Livro>, ILivroRepository
    {
        public LivroRepository(IOptions<Settings> settings)
            : base(settings)
        {

        }

        public async Task<bool> VerificarISBN(string ISBN)
        {
            var filter = Builders<Livro>.Filter.Eq("ISBN.Numero", ISBN);
            var livro = await _context.Table
                                 .Find(filter)
                                 .FirstOrDefaultAsync();
            if (livro != null)
                return true;
            else
                return false;
        }
    }
}
