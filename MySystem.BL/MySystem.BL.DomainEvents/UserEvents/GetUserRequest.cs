using System;
using MySystem.DAL.Entities;

namespace MySystem.BL.DomainEvents
{
    public class GetUserRequest
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public GetUserRequest(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }
    }
}
