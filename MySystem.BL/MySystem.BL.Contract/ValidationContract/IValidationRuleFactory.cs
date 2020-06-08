using System;
using System.Collections.Generic;
using System.Text;

namespace MySystem.BL.Contract
{
    public interface IValidationRuleFactory
    {
        IEnterValidationRule CreateEnterValidationRule();
        IUpdateAccountValidationRule CreateUpdateAccountValidationRule();
        IDataNotesValidationRule CreateDataNotesValidationRule();
    }
}
