using System;
using System.Collections.Generic;
using System.Text;

namespace MySystem.BL.DomainEvents
{
    public class GetAccountRequest
    {
        public int IdUser { get; set; }

        public GetAccountRequest(int idUser)
        {
            this.IdUser = idUser;
        }
    }
}
