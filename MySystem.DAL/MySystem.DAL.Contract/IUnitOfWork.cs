using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Entities;

namespace MySystem.DAL.Contract
{
    public interface IUnitOfWork
    {
        void GetUsersFromDatabase();
        void GetAccountsFromDatabase();
        void GetNotesFromDatabase();
        IRepository<User> Users { get; }
        IRepository<Account> Accounts { get; }
        IRepository<Notes> Noteses { get; }
    }
}
