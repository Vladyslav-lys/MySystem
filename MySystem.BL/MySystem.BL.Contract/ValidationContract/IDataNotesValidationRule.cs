using System;
using System.Collections.Generic;
using System.Text;

namespace MySystem.BL.Contract
{
    public interface IDataNotesValidationRule
    {
        ValidResult ValidateTopic(string topic);

        ValidResult ValidateText(string text);

        ValidResult ValidateDate(DateTime date);

        void RefreshValidResult();
    }
}
