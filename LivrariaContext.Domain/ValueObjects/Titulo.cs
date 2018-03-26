using Flunt.Validations;
using LivrariaContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Domain.ValueObjects
{
    public class Titulo : ValueObject
    {
        public Titulo(string tituloLivro)
        {
            TituloLivro = tituloLivro;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(TituloLivro, 5, "Titulo.TituloLivro", "O título do livro deve conter pelo menos 5 caracteres")
            );
        }

        public string TituloLivro { get; private set; }
    }
}
