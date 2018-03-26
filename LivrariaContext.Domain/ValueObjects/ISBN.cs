using Flunt.Validations;
using LivrariaContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Domain.ValueObjects
{
    public class ISBN : ValueObject
    {
        public ISBN(string numero)
        {
            Numero = numero;

            AddNotifications(new Contract()
                .Requires()
                .HasLen(Numero, 13, "ISBN.Numero", "O ISBN inválido. ISBN deve conter 13 dígitos.")
            );
        }

        public string Numero { get; private set; }

    }
}
