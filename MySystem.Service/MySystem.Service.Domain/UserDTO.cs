using System;

namespace MySystem.Service.Domain
{
    public class UserDTO
    {
        private int id;
        private string login;
        private string password;

        public int Id
        {
            get { return id; }
            set { this.id = value; }
        }

        public string Login
        {
            get { return login; }
            set { this.login = value; }
        }

        public string Password
        {
            get { return password; }
            set { this.password = value; }
        }

        public UserDTO(int id, string login, string password)
        {
            this.id = id;
            this.login = login;
            this.password = password;
        }
    }
}
