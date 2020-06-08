using System;
using System.Collections.Generic;
using System.Text;
using MySystem.BL.Contract;
using MySystem.BL.DomainEvents;

namespace MySystem.BL.Activities
{
    public class EditValidationAccountActivity : IValidationActivity<EditAccountRequest>
    {
        private IUpdateAccountValidationRule updateAccountValidationRule;

        public EditValidationAccountActivity(IUpdateAccountValidationRule updateAccountValidationRule)
        {
            this.updateAccountValidationRule = updateAccountValidationRule;
        }

        public void Validate(EditAccountRequest requestEditEvent)
        {
            ValidResult validResultLastName = updateAccountValidationRule.ValidateLastName(requestEditEvent.LastName);
            ValidResult validResultFirstName = updateAccountValidationRule.ValidateFirstName(requestEditEvent.FirstName);
            ValidResult validResultSecondName = updateAccountValidationRule.ValidateSecondName(requestEditEvent.SecondName);

            if (validResultLastName.GetError().Length > 0)
            {
                throw new Exception(validResultLastName.GetError());
            }
            else if (validResultFirstName.GetError().Length > 0)
            {
                throw new Exception(validResultFirstName.GetError());
            }
            else if (validResultSecondName.GetError().Length > 0)
            {
                throw new Exception(validResultSecondName.GetError());
            }
        }
    }
}
