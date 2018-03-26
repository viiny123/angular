using Flunt.Validations;
using LivrariaContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Endereco(string rua, string numero, string bairro, string cidade, string estado, string cep)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Rua, "Endereco.Rua", "A rua é obrigatório")
                .IsNotNullOrEmpty(Numero, "Endereco.Numero", "O número é obrigatório")
                .IsNotNullOrEmpty(Bairro, "Endereco.Bairro", "O bairro é obrigatório")
                .IsNotNullOrEmpty(Cidade, "Endereco.Cidade", "O cidade é obrigatório")
                .IsNotNullOrEmpty(Estado, "Endereco.Estado", "O estado é obrigatório")
                .IsNotNullOrEmpty(Cep, "Endereco.Cep", "O cep é obrigatório!")
                .HasMinLen(Cep, 8, "Endereco.Cep", "O cep deve conter pelo menos 8 caracteres")
            );
        }

        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep { get; private set; }
    }
}
