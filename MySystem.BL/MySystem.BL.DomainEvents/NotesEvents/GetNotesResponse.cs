using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Entities;

namespace MySystem.BL.DomainEvents
{
    public class GetNotesResponse
    {
        public List<Notes> Notes { get; set; }

        public GetNotesResponse(List<Notes> notes)
        {
            this.Notes = notes;
        }
    }
}
