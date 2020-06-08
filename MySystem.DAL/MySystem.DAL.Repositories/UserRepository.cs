using System;
using MySystem.DAL.Contract;
using MySystem.DAL.Entities;
using MySystem.DAL.Contexts;
using System.Linq;
using System.Collections.Generic;

namespace MySystem.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private DBContext db;

        public UserRepository(DBContext context)
        {
            this.db = context;
        }

        public List<User> GetAll()
        {
            return db.Users;
        }

        public void GetNewAll()
        {
            db.GetUsersFromDatabase();
        }

        public User Get(string login, string password)
        {
            foreach (User user in this.GetAll())
            {
                if (user.Login.Equals(login) && user.Password.Equals(password))
                    return user;
            }
            return null;
        }

        public void Create(User user)
        {
            if (user != null)
            {
                db.InsertUser(user);
            }
        }

        public void Update(User user)
        {
            if (user != null)
            {
                for (int i = 0; i < this.GetAll().Count; i++)
                {
                    if (db.Users[i].Id == user.Id)
                    {
                        db.Users[i].Login = user.Login;
                        db.Users[i].Password = user.Password;
                    }
                }
                db.UpdateUser(user);
            }
        }

        public User Find(User user)
        {
            foreach (User curUser in this.GetAll())
            {
                if (curUser.Id == user.Id)
                    return curUser;
            }
            return null;
        }

        public void Delete(User user)
        {
            User curUser = this.Find(user);

            if (curUser != null)
            {
                db.DropUser(user);
                db.Users.Remove(curUser);
            }
        }
    }
}
