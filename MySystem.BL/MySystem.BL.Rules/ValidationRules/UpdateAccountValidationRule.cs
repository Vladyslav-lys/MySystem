using System;
using System.Collections.Generic;
using System.Text;
using MySystem.BL.Contract;

namespace MySystem.BL.Rules
{
    public class UpdateAccountValidationRule : ValidationBase, IUpdateAccountValidationRule
    {
        public UpdateAccountValidationRule() : base()
        {

        }

        public ValidResult ValidateLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName) || !lastName.IsString())
            {
                validResult = new ValidResult(false, "Lastname must have: letters only");
            }
            return validResult;
        }

        public ValidResult ValidateFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName) || !firstName.IsString())
            {
                validResult = new ValidResult(false, "Firstname must have: letters only");
            }
            return validResult;
        }

        public ValidResult ValidateSecondName(string secondName)
        {
            if (string.IsNullOrEmpty(secondName) || !secondName.IsString())
            {
                validResult = new ValidResult(false, "Secondname must have: letters only");
            }
            return validResult;
        }

        public void RefreshValidResult()
        {
            validResult = new ValidResult();
        }
    }
}
