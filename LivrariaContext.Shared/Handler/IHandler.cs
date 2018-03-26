using LivrariaContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaContext.Shared.Handler
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
        Task<List<ICommandResult>> Get();
        Task<ICommandResult> GetById(string id);

        Task<ICommandResult> Delete(string id);
    }
}
