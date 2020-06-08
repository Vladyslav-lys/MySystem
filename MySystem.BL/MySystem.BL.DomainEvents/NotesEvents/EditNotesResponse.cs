using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Entities;

namespace MySystem.BL.DomainEvents
{
    public class EditNotesResponse
    {
        public List<Notes> Notes { get; set; }

        public EditNotesResponse(List<Notes> notes)
        {
            this.Notes = notes;
        }
    }
}
