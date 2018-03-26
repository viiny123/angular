using Flunt.Notifications;
using LivrariaContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Domain.Commands
{
    public class CommandResult : Notifiable, ICommandResult
    {
        public CommandResult()
        {

        }

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
