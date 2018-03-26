using System;
using System.Collections.Generic;
using System.Text;
using LivrariaContext.Domain.Commands;
using LivrariaContext.Domain.Handlers;
using LivrariaContext.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LivrariaContext.Tests.Handlers
{
    [TestClass]
    public class LivroHandlerTest
    {
        [TestMethod]
        public  void RetornaErroCasoISBNExista()
        {
            var handler = new LivroHandler(new FakeLivroRepository());
            var command = new CreateLivroCommand();
            command.Ano = "2017";
            command.Bairro = "bairro";
            command.Cep = "87033080";
            command.Cidade = "Curitiba";
            command.Cnpj = "01146492000190";
            command.Estado = "PR";
            command.Estoque = 10;
            command.Formato = "10x16";
            command.ISBN = "1252658623641";
            command.Nome = "Nome Autor";
            command.Sobrenome = "Sobrenome Autor";
            command.TituloLivro = "Titulo Livro";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}
