using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Contract;
using MySystem.DAL.Entities;
using MySystem.BL.DomainEvents;
using MySystem.BL.Contract;

namespace MySystem.BL.Activities
{
    public class EditAccountActivity : IEditAccountActivity
    {
        private IRepository<Account> accountRepository;

        public EditAccountActivity(IRepository<Account> accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Account Run(int id, string lastName, string firstName, string secondName, byte[] photo)
        {
            Account account = null;

            foreach(Account curAccount in accountRepository.GetAll())
            {
                if(id.Equals(curAccount.Id))
                {
                    account = new Account()
                    {
                        Id = id,
                        LastName = lastName,
                        FirstName = firstName,
                        SecondName = secondName,
                        Photo = photo
                    };
                    accountRepository.Update(account);
                }
            }

            if(account == null)
                throw new Exception("The account is not updated and not found!");

            return account;
        }
    }
}
