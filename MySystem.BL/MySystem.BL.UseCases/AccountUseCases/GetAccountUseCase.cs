using System;
using MySystem.BL.Contract;
using MySystem.BL.DomainEvents;
using MySystem.DAL.Entities;

namespace MySystem.BL.UseCases
{
    public class GetAccountUseCase : IUseCase<GetAccountResponse, GetAccountRequest>
    {
        private IGetAccountActivity getAccountActivity;

        public GetAccountUseCase(IGetAccountActivity getAccountActivity)
        {
            this.getAccountActivity = getAccountActivity;
        }

        public GetAccountResponse Execute(GetAccountRequest getAccountRequest)
        {
            try
            {
                Account account = getAccountActivity.Run(getAccountRequest.IdUser);
                return new GetAccountResponse(account);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
