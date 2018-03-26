using Flunt.Notifications;
using LivrariaContext.Domain.Commands;
using LivrariaContext.Domain.Entities;
using LivrariaContext.Domain.Repository.Interfaces;
using LivrariaContext.Domain.ValueObjects;
using LivrariaContext.Shared.Commands;
using LivrariaContext.Shared.Handler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LivrariaContext.Domain.Handlers
{
    public class LivroHandler : Notifiable,
        IHandler<CreateLivroCommand>,
        IHandler<UpdateLivroCommand>
    {
        private readonly ILivroRepository _livroRepository;
        public LivroHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<ICommandResult> Handle(CreateLivroCommand command)
        {
            var livroExists = await _livroRepository.VerificarISBN(command.ISBN);

            if (livroExists)
            {
                AddNotification("ISBN", "ISBN já existe na base de dados");
                return new CommandResult(false, "Não foi possivel realizar a operação");
            }

            // gerar os VOs
            var titulo = new Titulo(command.TituloLivro);
            var autor = new Autor(command.Nome, command.Sobrenome);
            var editora = new Editora(command.NomeEditora, command.Cnpj, new Endereco(command.Rua, command.Numero, command.Bairro, command.Cidade, command.Estado, command.Cep));
            var isbn = new ISBN(command.ISBN);
            var estoque = new Estoque(command.Estoque);

            //gerar entidade
            var livro = new Livro(titulo, autor, editora, command.Formato, command.Peso, command.Paginas, isbn, command.Ano, estoque);

            //agrupar as notificações.
            AddNotifications(titulo, autor, editora, isbn, estoque, livro);

            if (Invalid)
            {
                //retorna notificações..
                return new CommandResult(false, "Não foi possivel realizar a operação");
            }

            //criar livro
            await _livroRepository.Add(livro);

            return new CommandResult(true, "Cadastro realizado com sucesso!");
        }

        public async Task<ICommandResult> Handle(UpdateLivroCommand command)
        {
            // gerar os VOs
            var titulo = new Titulo(command.TituloLivro);
            var autor = new Autor(command.Nome, command.Sobrenome);
            var editora = new Editora(command.NomeEditora, command.Cnpj, new Endereco(command.Rua, command.Numero, command.Bairro, command.Cidade, command.Estado, command.Cep));
            var isbn = new ISBN(command.ISBN);
            var estoque = new Estoque(command.Estoque);

            //gerar entidade
            var livro = new Livro(command.Id, titulo, autor, editora, command.Formato, command.Peso, command.Paginas, isbn, command.Ano, estoque);

            //agrupar as notificações.
            AddNotifications(titulo, autor, editora, isbn, estoque, livro);

            if (Invalid)
            {
                //retorna notificações..
                return new CommandResult(false, "Não foi possivel realizar a operação");
            }

            //atualiza livro
            await _livroRepository.Update(livro);

            return new CommandResult(true, "Atualização realizada com sucesso!");
        }

        public async Task<ICommandResult> Handle(DeleteLivroCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel remover o registro.");
            }

            await _livroRepository.Remove(command.Id);

            return new CommandResult(true, "Registro removido com sucesso!");
        }

        public async Task<List<ICommandResult>> Get()
        {
            var result = new List<ICommandResult>();

            var livros = await _livroRepository.GetAll();

            foreach (var item in livros)
            {
                result.Add(new GetLivrosCommandResult(item._id, item.Titulo.TituloLivro, item.Autor.ToString(), item.Editora.NomeEditora, item.ISBN.Numero));
            }

            return result;
        }

        public async Task<ICommandResult> GetById(string id)
        {
            var livro = await _livroRepository.Get(id);

            try
            {
                var result = new GetLivroCommandResult(
                        livro._id,
                        livro.Titulo.TituloLivro,
                        livro.Autor.Nome,
                        livro.Autor.Sobrenome,
                        livro.Editora.NomeEditora,
                        livro.Editora.Cnpj,
                        livro.Editora.Endereco.Rua,
                        livro.Editora.Endereco.Numero,
                        livro.Editora.Endereco.Bairro,
                        livro.Editora.Endereco.Cidade,
                        livro.Editora.Endereco.Estado,
                        livro.Editora.Endereco.Cep,
                        livro.Formato,
                        livro.Peso,
                        livro.Paginas,
                        livro.ISBN.Numero,
                        livro.Ano,
                        livro.Estoque.Quantidade
                        );

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ICommandResult> Delete(string id)
        {
            await _livroRepository.Remove(id);

            return new CommandResult(true, "Registro removido com sucesso!");
        }
    }
}
