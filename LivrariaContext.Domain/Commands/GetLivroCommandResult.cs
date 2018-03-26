using Flunt.Notifications;
using LivrariaContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Domain.Commands
{
    public class GetLivroCommandResult : Notifiable, ICommandResult
    {
        public GetLivroCommandResult(
            string id,
            string tituloLivro, 
            string nome, 
            string sobrenome, 
            string nomeEditora, 
            string cnpj, 
            string rua, 
            string numero, 
            string bairro, 
            string cidade, 
            string estado, 
            string cep, 
            string formato, 
            decimal peso, 
            int paginas, 
            string iSBN, 
            string ano, 
            int estoque
            )
        {
            this.id = id;
            TituloLivro = tituloLivro;
            Nome = nome;
            Sobrenome = sobrenome;
            NomeEditora = nomeEditora;
            Cnpj = cnpj;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Formato = formato;
            Peso = peso;
            Paginas = paginas;
            ISBN = iSBN;
            Ano = ano;
            Estoque = estoque;
        }

        public string id { get; set; }
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
    }
}
