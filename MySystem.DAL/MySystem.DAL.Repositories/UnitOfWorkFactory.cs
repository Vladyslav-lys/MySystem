using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Contract;

namespace MySystem.DAL.Repositories
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public UnitOfWorkFactory()
        {
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork();
        }
    }
}
