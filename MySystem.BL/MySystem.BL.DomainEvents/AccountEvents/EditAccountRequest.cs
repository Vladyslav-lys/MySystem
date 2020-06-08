using System;
using System.Collections.Generic;
using System.Text;

namespace MySystem.BL.DomainEvents
{
    public class EditAccountRequest
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public byte[] Photo { get; set; }

        public EditAccountRequest(int id, string lastName, string firstName, string secondName, byte[] photo)
        {
            this.Id = id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Photo = photo;
        }
    }
}
