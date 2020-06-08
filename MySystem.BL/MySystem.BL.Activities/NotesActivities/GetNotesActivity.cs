using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Contract;
using MySystem.DAL.Entities;
using MySystem.BL.DomainEvents;
using MySystem.BL.Contract;

namespace MySystem.BL.Activities
{
    public class GetNotesActivity : IGetNotesActivity
    {
        private IRepository<Notes> notesRepository;

        public GetNotesActivity(IRepository<Notes> notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public List<Notes> Run(int idAccount)
        {
            List<Notes> noteses = new List<Notes>();

            notesRepository.GetNewAll();
            foreach (Notes curNotes in notesRepository.GetAll())
            {
                if (idAccount.Equals(curNotes.IdAccount))
                {
                    Notes notes = new Notes()
                    {
                        Id = curNotes.Id,
                        Topic = curNotes.Topic,
                        Text = curNotes.Text,
                        Date = curNotes.Date,
                        Image = curNotes.Image,
                        IdAccount = curNotes.IdAccount
                    };
                    noteses.Add(notes);
                } 
            }

            return noteses;
        }
    }
}
