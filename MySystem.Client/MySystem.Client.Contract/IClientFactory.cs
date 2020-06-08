using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySystem.Client.Contract
{
    public interface IClientFactory
    {
        IMainClient CreateMainClient();
    }
}
