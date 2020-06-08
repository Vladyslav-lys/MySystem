using System;
using MySystem.BL.Contract;
using MySystem.BL.DomainEvents;

namespace MySystem.BL.UseCases
{
    public class UseCaseFactory : IUseCaseFactory
    {
        private IActivityFactory activityFactory;

        public UseCaseFactory(IActivityFactory activityFactory)
        {
            this.activityFactory = activityFactory;
        }

        public IUseCase<GetUserResponse, GetUserRequest> CreateLoginUseCase()
        {
            return new LoginUseCase(activityFactory.CreateLoginValidationActivity(), activityFactory.CreateGetUserActivity());
        }

        public IUseCase<GetAccountResponse, GetAccountRequest> CreateGetAccountUseCase()
        {
            return new GetAccountUseCase(activityFactory.CreateGetAccountActivity());
        }

        public IUseCase<EditAccountResponse,EditAccountRequest> CreateEditAccountUseCase()
        {
            return new EditAccountUseCase(activityFactory.CreateEditAccountValidationActivity(), activityFactory.CreateEditAccountActivity());
        }

        public IUseCase<GetNotesResponse, GetNotesRequest> CreateGetNotesUseCase()
        {
            return new GetNotesUseCase(activityFactory.CreateGetNotesActivity());
        }

        public IUseCase<EditNotesResponse, EditNotesRequest> CreateEditNotesUseCase()
        {
            return new EditNotesUseCase(activityFactory.CreateEditNotesValidationActivity(), activityFactory.CreateEditNotesActivity(), activityFactory.CreateGetNotesActivity());
        }

        public IUseCase<AddNotesResponse, AddNotesRequest> CreateAddNotesUseCase()
        {
            return new AddNotesUseCase(activityFactory.CreateAddNotesValidationActivity(), activityFactory.CreateAddNotesActivity(), activityFactory.CreateGetNotesActivity());
        }
    }
}
