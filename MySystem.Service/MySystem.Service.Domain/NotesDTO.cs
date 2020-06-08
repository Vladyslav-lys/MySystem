using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MySystem.Service.Domain
{
    public class NotesDTO
    {
        private int id;
        private string topic;
        private string text;
        private DateTime date;
        private byte[] image;
        private int idAccount;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public byte[] Image
        {
            get { return image; }
            set { image = value; }
        }

        public int IdAccount
        {
            get { return idAccount; }
            set { idAccount = value; }
        }

        public NotesDTO() { }

        public NotesDTO(int id, string topic, string text, DateTime date, byte[] image, int idAccount)
        {
            this.id = id;
            this.topic = topic;
            this.text = text;
            this.date = date;
            this.image = image;
            this.idAccount = idAccount;
        }
    }
}
