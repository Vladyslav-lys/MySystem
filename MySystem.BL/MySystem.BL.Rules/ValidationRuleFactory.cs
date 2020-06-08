using System;
using System.Collections.Generic;
using System.Text;
using MySystem.BL.Contract;

namespace MySystem.BL.Rules
{
    public class ValidationRuleFactory : IValidationRuleFactory
    {
        public ValidationRuleFactory() { }
        
        public IEnterValidationRule CreateEnterValidationRule()
        {
            return new EnterValidationRule();
        }

        public IUpdateAccountValidationRule CreateUpdateAccountValidationRule()
        {
            return new UpdateAccountValidationRule();
        }

        public IDataNotesValidationRule CreateDataNotesValidationRule()
        {
            return new DataNotesValidationRule();
        }
    }
}
