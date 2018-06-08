using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaContext.Domain.Commands;
using LivrariaContext.Domain.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hbsisApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Livro")]
    public class LivroController : BaseController
    {
        private readonly LivroHandler _handler;

        public LivroController(LivroHandler livroHandler)
        {
            _handler = livroHandler;
        }

        // GET: api/Livro
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var livros = await _handler.Get();

            return await Response(livros, _handler.Notifications);
        }

        // GET: api/Livro/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(string id)
        {
            var livro = await _handler.GetById(id);

            return await Response(livro, _handler.Notifications);
        }

        // POST: api/Livro
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateLivroCommand command)
        {
            var result = await _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }

        // PUT: api/Livro/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UpdateLivroCommand command)
        {
            var result = await _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }

        // DELETE: api/Livro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _handler.Delete(id);
            return await Response(result, _handler.Notifications);
        }
    }
}
