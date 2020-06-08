using System;
using System.Collections.Generic;
using System.Text;
using MySystem.BL.DomainEvents;

namespace MySystem.BL.Contract
{
    public interface IUseCaseFactory
    {
        IUseCase<GetUserResponse, GetUserRequest> CreateLoginUseCase();
        IUseCase<GetAccountResponse, GetAccountRequest> CreateGetAccountUseCase();
        IUseCase<EditAccountResponse, EditAccountRequest> CreateEditAccountUseCase();
        IUseCase<GetNotesResponse, GetNotesRequest> CreateGetNotesUseCase();
        IUseCase<EditNotesResponse, EditNotesRequest> CreateEditNotesUseCase();
        IUseCase<AddNotesResponse, AddNotesRequest> CreateAddNotesUseCase();
    }
}
