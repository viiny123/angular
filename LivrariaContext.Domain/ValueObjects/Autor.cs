using Flunt.Validations;
using LivrariaContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Domain.ValueObjects
{
    public class Autor : ValueObject
    {
        public Autor(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome, "Autor.Nome", "O Nome do autor é obrigatório!")
                .IsNotNullOrEmpty(Sobrenome, "Autor.Sobrenome", "O Sobrenome do autor é obrigatório!")
            );
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        public override string ToString()
        {
            return $"{Sobrenome},{Nome}";
        }
    }
}
