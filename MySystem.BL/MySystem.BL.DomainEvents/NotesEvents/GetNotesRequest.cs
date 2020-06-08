using System;
using System.Collections.Generic;
using System.Text;

namespace MySystem.BL.DomainEvents
{
    public class GetNotesRequest
    {
        public int IdAccount { get; set; }

        public GetNotesRequest(int idAccount)
        {
            this.IdAccount = idAccount;
        }
    }
}
