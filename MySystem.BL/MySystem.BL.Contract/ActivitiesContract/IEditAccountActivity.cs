using System;
using System.Collections.Generic;
using System.Text;
using MySystem.DAL.Entities;

namespace MySystem.BL.Contract
{
    public interface IEditAccountActivity
    {
        Account Run(int id, string lastName, string firstName, string secondName, byte[] photo);
    }
}
