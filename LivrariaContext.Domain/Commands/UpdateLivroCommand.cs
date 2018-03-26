using Flunt.Notifications;
using LivrariaContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Domain.Commands
{
    public class UpdateLivroCommand : Notifiable, ICommand
    {
        public string Id { get; set; }
        public string TituloLivro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeEditora { get; set; }
        public string Cnpj { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Formato { get; set; }
        public decimal Peso { get; set; }
        public int Paginas { get; set; }
        public string ISBN { get; set; }
        public string Ano { get; set; }
        public int Estoque { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
