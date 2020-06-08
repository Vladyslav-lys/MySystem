using System;
using MySystem.DAL.Contract;
using MySystem.DAL.Entities;
using MySystem.DAL.Contexts;
using System.Linq;
using System.Collections.Generic;

namespace MySystem.DAL.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private DBContext db;

        public AccountRepository(DBContext context)
        {
            this.db = context;
        }

        public List<Account> GetAll()
        {
            return db.Accounts;
        }

        public void GetNewAll()
        {
            db.GetAccountsFromDatabase();
        }

        public void Create(Account account)
        {
            if (account != null)
            {
                db.InsertAccount(account);
            }
        }

        public void Delete(Account account)
        {
            Account curAccount = this.Find(account);

            if (curAccount != null)
            {
                db.DropAccount(account);
                db.Accounts.Remove(curAccount);
            }
        }

        public Account Find(Account account)
        {
            foreach (Account curAccount in this.GetAll())
            {
                if (curAccount.Id == account.Id)
                    return curAccount;
            }
            return null;
        }

        public void Update(Account account)
        {
            if (account != null)
            {
                for (int i = 0; i < this.GetAll().Count; i++)
                {
                    if (db.Accounts[i].Id == account.Id)
                    {
                        db.Accounts[i].LastName = account.LastName;
                        db.Accounts[i].FirstName = account.FirstName;
                        db.Accounts[i].SecondName = account.SecondName;
                        db.Accounts[i].Photo = account.Photo;
                    }
                }
                db.UpdateAccount(account);
            }
        }
    }
}
