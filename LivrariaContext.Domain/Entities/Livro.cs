using Flunt.Validations;
using LivrariaContext.Domain.ValueObjects;
using LivrariaContext.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Domain.Entities
{
    public class Livro : Entity
    {
        public Livro(Titulo titulo, Autor autor, Editora editora, string formato, decimal peso, int paginas, ISBN iSBN, string ano, Estoque estoque)
        {
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Formato = formato;
            Peso = peso;
            Paginas = paginas;
            ISBN = iSBN;
            Ano = ano;
            Estoque = estoque;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Formato, "Livro.Formato", "Formato é obrigatório")
                .IsGreaterOrEqualsThan(Peso,0m,"Livro.Peso", "Peso não pode ser menor ou igual a zero")
                .IsNotNullOrEmpty(Formato, "Livro.Ano", "Ano é obrigatório")
            );
        }

        public Livro(string id, Titulo titulo, Autor autor, Editora editora, string formato, decimal peso, int paginas, ISBN iSBN, string ano, Estoque estoque)
            : base(id)
        {
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Formato = formato;
            Peso = peso;
            Paginas = paginas;
            ISBN = iSBN;
            Ano = ano;
            Estoque = estoque;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Formato, "Livro.Formato", "Formato é obrigatório")
                .IsGreaterOrEqualsThan(Peso, 0m, "Livro.Peso", "Peso não pode ser menor ou igual a zero")
                .IsNotNullOrEmpty(Formato, "Livro.Ano", "Ano é obrigatório")
            );
        }

        public Titulo Titulo { get; private set; }
        public Autor Autor { get; private set; }
        public Editora Editora { get; private set; }
        public string Formato { get; private set; }
        public decimal Peso { get; private set; }
        public int Paginas { get; private set; }
        public ISBN ISBN { get; private set; }
        public string Ano { get; private set; }
        public Estoque Estoque { get; private set; }
    }
}
