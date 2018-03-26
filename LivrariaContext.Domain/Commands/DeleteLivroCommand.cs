using Flunt.Notifications;
using Flunt.Validations;
using LivrariaContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Domain.Commands
{
    public class DeleteLivroCommand : Notifiable, ICommand
    {
        public string Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Id, "DeleteLivroCommand.Id", "Id não pode ser vazio!")
            );
        }
    }
}
