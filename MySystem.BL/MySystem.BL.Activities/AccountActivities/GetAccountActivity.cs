using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Contract;
using MySystem.DAL.Entities;
using MySystem.BL.DomainEvents;
using MySystem.BL.Contract;

namespace MySystem.BL.Activities
{
    public class GetAccountActivity : IGetAccountActivity
    {
        private IRepository<Account> accountRepository;

        public GetAccountActivity(IRepository<Account> accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Account Run(int idUser)
        {
            Account account = null;

            accountRepository.GetNewAll();
            foreach (Account curAccount in accountRepository.GetAll())
            {
                if (idUser.Equals(curAccount.IdUser))
                    account = new Account()
                    {
                        Id = curAccount.Id,
                        LastName = curAccount.LastName,
                        FirstName = curAccount.FirstName,
                        SecondName = curAccount.SecondName,
                        Photo = curAccount.Photo
                    };
            }

            if (account == null)
                throw new Exception("The account is not found!");

            return account;
        }
    }
}
