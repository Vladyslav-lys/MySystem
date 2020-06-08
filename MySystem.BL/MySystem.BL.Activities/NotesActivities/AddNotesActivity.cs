using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Contract;
using MySystem.DAL.Entities;
using MySystem.BL.DomainEvents;
using MySystem.BL.Contract;
using System.Drawing;

namespace MySystem.BL.Activities
{
    public class AddNotesActivity : IAddNotesActivity
    {
        private IRepository<Notes> notesRepository;

        public AddNotesActivity(IRepository<Notes> notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public void Run(string topic, string text, DateTime date, byte[] image, int idAccount)
        {
            Notes newNotes = new Notes()
            {
                Topic = topic,
                Text = text,
                Date = date,
                Image = image,
                IdAccount = idAccount
            };
            notesRepository.Create(newNotes);
        }
    }
}
