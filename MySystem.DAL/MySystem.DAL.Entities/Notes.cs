using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MySystem.DAL.Entities
{
    public class Notes
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
    }
}
