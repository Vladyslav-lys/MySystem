using System;
using MySystem.DAL.Contract;
using MySystem.DAL.Entities;
using MySystem.BL.Contract;
using MySystem.BL.DomainEvents;
using MySystem.BL.Rules;

namespace MySystem.BL.Activities
{
    public class ActivityFactory : IActivityFactory
    {
        private IValidationRuleFactory validationRuleFactory;
        private IUnitOfWork unitOfWork;

        public ActivityFactory(IUnitOfWork unitOfWork, IValidationRuleFactory validationRuleFactory)
        {
            this.unitOfWork = unitOfWork;
            this.validationRuleFactory = validationRuleFactory;
        }
        
        public IValidationActivity<GetUserRequest> CreateLoginValidationActivity()
        {
            return new LoginValidationActivity(validationRuleFactory.CreateEnterValidationRule());
        }

        public IValidationActivity<EditAccountRequest> CreateEditAccountValidationActivity()
        {
            return new EditValidationAccountActivity(validationRuleFactory.CreateUpdateAccountValidationRule());
        }

        public IValidationActivity<EditNotesRequest> CreateEditNotesValidationActivity()
        {
            return new EditValidationNotesActivity(validationRuleFactory.CreateDataNotesValidationRule());
        }

        public IValidationActivity<AddNotesRequest> CreateAddNotesValidationActivity()
        {
            return new AddValidationNotesActivity(validationRuleFactory.CreateDataNotesValidationRule());
        }

        public IGetUserActivity CreateGetUserActivity()
        {
            return new GetUserActivity(unitOfWork.Users);
        }

        public IGetAccountActivity CreateGetAccountActivity()
        {
            return new GetAccountActivity(unitOfWork.Accounts);
        }

        public IEditAccountActivity CreateEditAccountActivity()
        {
            return new EditAccountActivity(unitOfWork.Accounts);
        }

        public IGetNotesActivity CreateGetNotesActivity()
        {
            return new GetNotesActivity(unitOfWork.Noteses);
        }

        public IEditNotesActivity CreateEditNotesActivity()
        {
            return new EditNotesActivity(unitOfWork.Noteses);
        }

        public IAddNotesActivity CreateAddNotesActivity()
        {
            return new AddNotesActivity(unitOfWork.Noteses);
        }
    }
}
