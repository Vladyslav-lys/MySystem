using System;
using System.Collections.Generic;
using System.Text;

namespace MySystem.BL.Contract
{
    public interface IUpdateAccountValidationRule
    {
        ValidResult ValidateLastName(string lastName);
        
        ValidResult ValidateFirstName(string firstName);

        ValidResult ValidateSecondName(string secondName);

        void RefreshValidResult();
    }
}
