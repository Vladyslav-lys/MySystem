using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Entities;

namespace MySystem.BL.DomainEvents
{
    public class AddNotesResponse
    {
        public List<Notes> Notes { get; set; }

        public AddNotesResponse(List<Notes> notes)
        {
            this.Notes = notes;
        }
    }
}
