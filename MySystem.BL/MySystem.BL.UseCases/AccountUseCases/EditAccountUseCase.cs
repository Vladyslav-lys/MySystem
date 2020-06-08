using System;
using System.Collections.Generic;
using System.Text;
using MySystem.BL.DomainEvents;
using MySystem.BL.Contract;
using MySystem.DAL.Entities;

namespace MySystem.BL.UseCases
{
    public class EditAccountUseCase : IUseCase<EditAccountResponse, EditAccountRequest>
    {
        private IValidationActivity<EditAccountRequest> editAccountValidationActivity;
        private IEditAccountActivity editAccountActivity;

        public EditAccountUseCase(IValidationActivity<EditAccountRequest> editAccountValidationActivity, IEditAccountActivity editAccountActivity)
        {
            this.editAccountValidationActivity = editAccountValidationActivity;
            this.editAccountActivity = editAccountActivity;
        }

        public EditAccountResponse Execute(EditAccountRequest request)
        {
            try
            {
                editAccountValidationActivity.Validate(request);
                Account account = editAccountActivity.Run(request.Id, request.LastName, request.FirstName, request.SecondName, request.Photo);
                return new EditAccountResponse(account);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
