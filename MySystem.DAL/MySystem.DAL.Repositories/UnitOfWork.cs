using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Contract;
using MySystem.DAL.Contexts;
using MySystem.DAL.Entities;

namespace MySystem.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DBContext db;
        private UserRepository userRepository;
        private AccountRepository accountRepository;
        private NotesRepository notesRepository;
        private bool disposed = false;

        public UnitOfWork()
        {
            this.db = new DBContext();
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(this.db);
                return userRepository;
            }
        }

        public IRepository<Account> Accounts
        {
            get
            {
                if (accountRepository == null)
                    accountRepository = new AccountRepository(this.db);
                return accountRepository;
            }
        }

        public IRepository<Notes> Noteses
        {
            get
            {
                if (notesRepository == null)
                    notesRepository = new NotesRepository(this.db);
                return notesRepository;
            }
        }

        public void GetUsersFromDatabase()
        {
            db.GetUsersFromDatabase();
        }

        public void GetAccountsFromDatabase()
        {
            db.GetAccountsFromDatabase();
        }

        public void GetNotesFromDatabase()
        {
            db.GetNotesFromDatabase();
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.db.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
