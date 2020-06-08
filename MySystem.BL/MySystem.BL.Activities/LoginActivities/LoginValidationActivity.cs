using System;
using System.Collections.Generic;
using System.Text;
using MySystem.BL.Contract;
using MySystem.BL.DomainEvents;

namespace MySystem.BL.Activities
{
    public class LoginValidationActivity : IValidationActivity<GetUserRequest>
    {
        private IEnterValidationRule enterValidationRule;

        public LoginValidationActivity(IEnterValidationRule enterValidationRule)
        {
            this.enterValidationRule = enterValidationRule;
        }

        public void Validate(GetUserRequest requsetUserEvent)
        {
            ValidResult validResultLogin = enterValidationRule.ValidateLogin(requsetUserEvent.Login);
            ValidResult validResultPassword = enterValidationRule.ValidatePassword(requsetUserEvent.Password);

            if (validResultLogin.GetError().Length > 0 )
            {
                throw new Exception(validResultLogin.GetError());
            }
            else if(validResultPassword.GetError().Length > 0)
            {
                throw new Exception(validResultPassword.GetError());
            }
        }
    }
}
