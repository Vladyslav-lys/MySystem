using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Entities;
using System.Drawing;

namespace MySystem.BL.Contract
{
    public interface IAddNotesActivity
    {
        void Run(string topic, string text, DateTime date, byte[] image, int idAccount);
    }
}
