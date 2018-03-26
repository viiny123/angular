using Flunt.Validations;
using LivrariaContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Domain.ValueObjects
{
    public class Estoque : ValueObject
    {
        public Estoque(int quantidade)
        {
            Quantidade = quantidade;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(Quantidade, 1, "Estoque.Quantidade", "Estoque mínimo deve ser de um exemplar")
            );
        }

        public int Quantidade { get; private set; }
    }
}
