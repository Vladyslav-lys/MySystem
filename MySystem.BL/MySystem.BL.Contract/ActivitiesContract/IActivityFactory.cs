using System;
using System.Collections.Generic;
using System.Text;
using MySystem.BL.DomainEvents;

namespace MySystem.BL.Contract
{
    public interface IActivityFactory
    {
        IValidationActivity<GetUserRequest> CreateLoginValidationActivity();
        IValidationActivity<EditAccountRequest> CreateEditAccountValidationActivity();
        IValidationActivity<EditNotesRequest> CreateEditNotesValidationActivity();
        IValidationActivity<AddNotesRequest> CreateAddNotesValidationActivity();
        IGetUserActivity CreateGetUserActivity();
        IGetAccountActivity CreateGetAccountActivity();
        IEditAccountActivity CreateEditAccountActivity();
        IGetNotesActivity CreateGetNotesActivity();
        IEditNotesActivity CreateEditNotesActivity();
        IAddNotesActivity CreateAddNotesActivity();
    }
}
