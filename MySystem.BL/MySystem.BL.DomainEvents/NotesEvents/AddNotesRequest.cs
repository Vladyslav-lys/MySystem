using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MySystem.BL.DomainEvents
{
    public class AddNotesRequest
    {
        public string Topic { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public byte[] Image { get; set; }
        public int IdAccount { get; set; }

        public AddNotesRequest(string topic, string text, DateTime date, byte[] image, int idAccount)
        {
            this.Topic = topic;
            this.Text = text;
            this.Date = date;
            this.Image = image;
            this.IdAccount = idAccount;
        }
    }
}
