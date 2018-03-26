using Flunt.Notifications;
using LivrariaContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Domain.Commands
{
    public class GetLivrosCommandResult : Notifiable, ICommandResult
    {
        public GetLivrosCommandResult(string id, string tituloLivro, string autor, string nomeEditora, string iSBN)
        {
            this.id = id;
            TituloLivro = tituloLivro;
            Autor = autor;
            NomeEditora = nomeEditora;
            ISBN = iSBN;
        }

        public string id { get; set; }
        public string TituloLivro { get; set; }
        public string Autor { get; set; }
        public string NomeEditora { get; set; }
        public string ISBN { get; set; }
    }
}
