using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Entities;

namespace MySystem.BL.DomainEvents
{
    public class GetUserResponse
    {
        public User User { get; set; }

        public GetUserResponse(User user)
        {
            this.User = user;
        }
    }
}
