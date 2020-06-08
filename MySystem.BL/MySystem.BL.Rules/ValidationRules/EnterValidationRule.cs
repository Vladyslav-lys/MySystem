using System;
using System.Collections.Generic;
using System.Text;
using MySystem.BL.Contract;

namespace MySystem.BL.Rules
{
    public class EnterValidationRule : ValidationBase, IEnterValidationRule
    {
        public EnterValidationRule() : base()
        {

        }

        public ValidResult ValidateLogin(string login)
        {
            if (string.IsNullOrEmpty(login) || !login.IsStringWithNumbers())
            {
                validResult = new ValidResult(false, "Login must have: letters or digits");
            }
            return validResult;
        }

        public ValidResult ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password) || !password.IsStringWithNumbers())
            {
                validResult = new ValidResult(false, "Password must have: letters or digits");
            }
            return validResult;
        }

        public void RefreshValidResult()
        {
            validResult = new ValidResult();
        }
    }
}

//public class AccountProduct : ProductBase, IAccountProduct
//{
//    List<DAL.Entities.Account> accounts = null;

//    public AccountProduct(string connectionString) : base(connectionString)
//    {

//    }

//    public async Task<Account> GetAccountAsync(int idUser)
//    {
//        try
//        {
//            return await Task.Run(() =>
//            {
//                if (accounts == null)
//                {
//                    unitOfWork.GetAccountsFromDatabase();
//                    accounts = unitOfWork.Accounts.GetAll();
//                }

//                foreach (DAL.Entities.Account curAccount in accounts)
//                {
//                    if (curAccount.IdUser == idUser)
//                    {
//                        Domain.Account account = new Domain.Account()
//                        {
//                            Id = curAccount.Id,
//                            LastName = curAccount.LastName,
//                            FirstName = curAccount.FirstName,
//                            SecondName = curAccount.SecondName
//                        };
//                        return account;
//                    }
//                }
//                throw new Exception("The account is not found!");
//            });
//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message, ex);
//        }
//    }

//    public async Task<string> GetNotesAsync(int idUser)
//    {
//        try
//        {
//            return await Task.Run(() =>
//            {
//                if (accounts == null)
//                {
//                    unitOfWork.GetAccountsFromDatabase();
//                    accounts = unitOfWork.Accounts.GetAll();
//                }

//                foreach (DAL.Entities.Account curAccount in accounts)
//                {
//                    if (curAccount.IdUser == idUser)
//                    {
//                        string notes = curAccount.Notes;
//                        return notes;
//                    }
//                }
//                throw new Exception("The notes are not found!");
//            });
//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message, ex);
//        }
//    }

//    public async Task<bool> UpdateAccountAsync(Domain.Account account)
//    {
//        try
//        {
//            return await Task.Run(() =>
//            {
//                if (account != null)
//                {
//                    DAL.Entities.Account newAccount = new DAL.Entities.Account()
//                    {
//                        Id = account.Id,
//                        LastName = account.LastName,
//                        FirstName = account.FirstName,
//                        SecondName = account.SecondName
//                    };
//                    unitOfWork.Accounts.Update(newAccount);
//                    return true;
//                }
//                throw new Exception("The account is not updated!");
//            });
//        }
//        catch (Exception ex)
//        {
//            throw new Exception(ex.Message, ex);
//        }
//    }
//}





//public class ProfileValidation : ValidationBase, IProfileValidation
//{
//    public ProfileValidation() : base()
//    {

//    }

//    public ValidResult ValidateLastName(string lastName)
//    {
//        if (string.IsNullOrEmpty(lastName) || !lastName.IsString())
//        {
//            validResult = new ValidResult(false, "Last Name must have: letters only");
//        }
//        //else if(lastName[0] == char.ToUpper(lastName[0]))
//        //{
//        //    validResult = new ValidResult(false, "Last Name must have: first capital letter");
//        //}
//        return validResult;
//    }

//    public ValidResult ValidateFirstName(string firstName)
//    {
//        if (string.IsNullOrEmpty(firstName) || !firstName.IsString())
//        {
//            validResult = new ValidResult(false, "First Name must have: letters only");
//        }
//        //else if (firstName[0] == char.ToUpper(firstName[0]))
//        //{
//        //    validResult = new ValidResult(false, "First Name must have: first capital letter");
//        //}
//        return validResult;
//    }

//    public ValidResult ValidateSecondName(string secondName)
//    {
//        if (string.IsNullOrEmpty(secondName) || !secondName.IsString())
//        {
//            validResult = new ValidResult(false, "Second Name must have: letters only");
//        }
//        //else if (secondName[0] == char.ToUpper(secondName[0]))
//        //{
//        //    validResult = new ValidResult(false, "Second Name must have: first capital letter");
//        //}
//        return validResult;
//    }

//    public void RefreshValidResult()
//    {
//        validResult = new ValidResult();
//    }
//}