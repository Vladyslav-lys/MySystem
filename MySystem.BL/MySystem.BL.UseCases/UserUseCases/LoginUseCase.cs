using System;
using MySystem.BL.Contract;
using MySystem.BL.DomainEvents;
using MySystem.DAL.Entities;

namespace MySystem.BL.UseCases
{
    public class LoginUseCase : IUseCase<GetUserResponse, GetUserRequest>
    {
        private IValidationActivity<GetUserRequest> loginValidationActivity;
        private IGetUserActivity getUserActivity;

        public LoginUseCase(IValidationActivity<GetUserRequest> loginValidationActivity, IGetUserActivity getUserActivity)
        {
            this.loginValidationActivity = loginValidationActivity;
            this.getUserActivity = getUserActivity;
        }

        public GetUserResponse Execute(GetUserRequest request)
        {
            try
            {
                loginValidationActivity.Validate(request);
                User user = getUserActivity.Run(request.Login, request.Password);
                return new GetUserResponse(user);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
