using Flunt.Validations;
using LivrariaContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Domain.ValueObjects
{
    public class Editora : ValueObject
    {
        public Editora(string nomeEditora, string cnpj, Endereco endereco)
        {
            NomeEditora = nomeEditora;
            Cnpj = cnpj;
            Endereco = endereco;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(NomeEditora, "Editora.NomeEditora", "O nome da editora é obrigatório")
                .IsNotNullOrEmpty(Cnpj, "Editora.Cnpj", "O CNPJ é obrigatório")
            );
        }

        public string NomeEditora { get; private set; }
        public string Cnpj { get; private set; }
        public Endereco Endereco { get; private set; }
    }
}
