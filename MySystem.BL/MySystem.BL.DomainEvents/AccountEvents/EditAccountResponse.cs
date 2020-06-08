using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Entities;

namespace MySystem.BL.DomainEvents
{
    public class EditAccountResponse
    {
        public Account Account { get; set; }

        public EditAccountResponse(Account account)
        {
            this.Account = account;
        }
    }
}
