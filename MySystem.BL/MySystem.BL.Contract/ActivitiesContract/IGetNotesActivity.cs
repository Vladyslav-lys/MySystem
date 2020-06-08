using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Entities;

namespace MySystem.BL.Contract
{
    public interface IGetNotesActivity
    {
        List<Notes> Run(int idAccount);
    }
}
