using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Entities;

namespace MySystem.BL.DomainEvents
{
    public class GetAccountResponse
    {
        public Account Account { get; set; }

        public GetAccountResponse(Account account)
        {
            this.Account = account;
        }
    }
}
