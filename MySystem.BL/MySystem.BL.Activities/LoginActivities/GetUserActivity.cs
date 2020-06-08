using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Contract;
using MySystem.DAL.Entities;
using MySystem.BL.DomainEvents;
using MySystem.BL.Contract;

namespace MySystem.BL.Activities
{
    public class GetUserActivity : IGetUserActivity
    {
        private IRepository<User> userRepository;

        public GetUserActivity(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public User Run(string login, string password)
        {
            User user = null;

            userRepository.GetNewAll();
            foreach (User curUser in userRepository.GetAll())
            {
                if (login.Equals(curUser.Login) && password.Equals(curUser.Password))
                    user = new User() { Id = curUser.Id, Login = curUser.Login, Password = curUser.Password };
            }

            if (user == null)
                throw new Exception("The user is not found! Please, check out login or password");

            return user;
        }
    }
}
