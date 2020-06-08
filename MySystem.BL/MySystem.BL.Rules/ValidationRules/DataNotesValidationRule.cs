using System;
using System.Collections.Generic;
using System.Text;
using MySystem.BL.Contract;

namespace MySystem.BL.Rules
{
    public class DataNotesValidationRule : ValidationBase, IDataNotesValidationRule
    {
        public DataNotesValidationRule() : base()
        {

        }

        public ValidResult ValidateTopic(string topic)
        {
            if (string.IsNullOrEmpty(topic))
            {
                validResult = new ValidResult(false, "Topic must have any information!");
            }
            return validResult;
        }

        public ValidResult ValidateText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                validResult = new ValidResult(false, "Text must have any information!");
            }
            return validResult;
        }

        public ValidResult ValidateDate(DateTime date)
        {
            if (date == null)
            {
                validResult = new ValidResult(false, "Date must have any information!");
            }
            return validResult;
        }
        
        public void RefreshValidResult()
        {
           validResult = new ValidResult();
        }
    }
}
