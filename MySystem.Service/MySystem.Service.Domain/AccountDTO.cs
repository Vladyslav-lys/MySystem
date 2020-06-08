using System;
using System.Collections.Generic;
using System.Text;

namespace MySystem.Service.Domain
{
    public class AccountDTO
    {
        private int id;
        private string lastName;
        private string firstName;
        private string secondName;
        private byte[] photo;
        private int idUser;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }

        public byte[] Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }

        public AccountDTO(int id, string lastName, string firstName, string secondName, byte[] photo, int idUser)
        {
            this.id = id;
            this.lastName = lastName;
            this.firstName = firstName;
            this.secondName = secondName;
            this.photo = photo;
            this.idUser = idUser;
        }
    }
}
