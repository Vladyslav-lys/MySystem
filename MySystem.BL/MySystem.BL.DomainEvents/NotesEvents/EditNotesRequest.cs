using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MySystem.BL.DomainEvents
{
    public class EditNotesRequest
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public byte[] Image { get; set; }
        public int IdAccount { get; set; }

        public EditNotesRequest(int id, string topic, string text, DateTime date, byte[] image, int idAccount)
        {
            this.Id = id;
            this.Topic = topic;
            this.Text = text;
            this.Date = date;
            this.Image = image;
            this.IdAccount = idAccount;
        }
    }
}
