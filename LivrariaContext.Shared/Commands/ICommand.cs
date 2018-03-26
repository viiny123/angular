using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaContext.Shared.Commands
{
    public interface ICommand
    {
        void Validate();
    }
}
