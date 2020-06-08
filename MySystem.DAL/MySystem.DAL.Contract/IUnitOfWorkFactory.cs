using System;
using System.Collections.Generic;
using System.Text;

namespace MySystem.DAL.Contract
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();
    }
}
