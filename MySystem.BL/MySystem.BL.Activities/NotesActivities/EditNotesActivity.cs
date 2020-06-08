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
    public class EditNotesActivity : IEditNotesActivity
    {
        private IRepository<Notes> notesRepository;

        public EditNotesActivity(IRepository<Notes> notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public void Run(int id, string topic, string text, DateTime date, byte[] image, int idAccount)
        {
            Notes notes = null;

            foreach (Notes curNotes in notesRepository.GetAll())
            {
                if (id.Equals(curNotes.Id))
                {
                    notes = new Notes()
                    {
                        Id = id,
                        Topic = topic,
                        Text = text,
                        Date = date,
                        Image = image
                    };
                    notesRepository.Update(notes);
                    break;
                }
            }

            if (notes == null)
                throw new Exception("The notes are not updated and not found!");
        }
    }
}
