using System;
using System.Collections.Generic;
using System.Text;

namespace MySystem.BL.Contract
{
    public interface IEnterValidationRule
    {
        //Проверять логин
        ValidResult ValidateLogin(string login);

        //Проверять пароль
        ValidResult ValidatePassword(string password);

        void RefreshValidResult();
    }
}