using System;
using System.Collections.Generic;
using System.Text;
using MySystem.BL.Contract;
using MySystem.BL.DomainEvents;

namespace MySystem.BL.Activities
{
    public class EditValidationNotesActivity : IValidationActivity<EditNotesRequest>
    {
        private IDataNotesValidationRule dataAccountValidationRule;

        public EditValidationNotesActivity(IDataNotesValidationRule dataAccountValidationRule)
        {
            this.dataAccountValidationRule = dataAccountValidationRule;
        }

        public void Validate(EditNotesRequest request)
        {
            ValidResult validResultTopic = dataAccountValidationRule.ValidateTopic(request.Topic);
            ValidResult validResultText = dataAccountValidationRule.ValidateText(request.Text);
            ValidResult validResultDate = dataAccountValidationRule.ValidateDate(request.Date);

            if (validResultTopic.GetError().Length > 0)
            {
                throw new Exception(validResultTopic.GetError());
            }
            else if (validResultText.GetError().Length > 0)
            {
                throw new Exception(validResultText.GetError());
            }
            else if (validResultDate.GetError().Length > 0)
            {
                throw new Exception(validResultDate.GetError());
            }
        }
    }
}
