using System;
using MySystem.DAL.Contract;
using MySystem.DAL.Entities;
using MySystem.DAL.Contexts;
using System.Linq;
using System.Collections.Generic;

namespace MySystem.DAL.Repositories
{
    public class NotesRepository : IRepository<Notes>
    {
        private DBContext db;

        public NotesRepository(DBContext context)
        {
            this.db = context;
        }

        public List<Notes> GetAll()
        {
            return db.Noteses;
        }

        public void GetNewAll()
        {
            db.GetNotesFromDatabase();
        }

        public void Create(Notes notes)
        {
            if (notes != null)
            {
                db.InsertNotes(notes);
            }
        }

        public void Delete(Notes notes)
        {
            Notes curNotes = this.Find(notes);

            if (curNotes != null)
            {
                db.DropNotes(notes);
                db.Noteses.Remove(curNotes);
            }
        }

        public Notes Find(Notes notes)
        {
            foreach (Notes curNotes in this.GetAll())
            {
                if (curNotes.Id == notes.Id)
                    return curNotes;
            }
            return null;
        }

        public void Update(Notes notes)
        {
            if (notes != null)
            {
                for (int i = 0; i < this.GetAll().Count; i++)
                {
                    if (db.Noteses[i].Id == notes.Id)
                    {
                        db.Noteses[i].Topic = notes.Topic;
                        db.Noteses[i].Text = notes.Text;
                        db.Noteses[i].Date = notes.Date;
                        db.Noteses[i].Image = notes.Image;
                    }
                }
                db.UpdateNotes(notes);
            }
        }
    }
}
