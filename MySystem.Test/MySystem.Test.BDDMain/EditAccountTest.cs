using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using MySystem.DAL.Contract;
using MySystem.DAL.Repositories;
using NUnit.Framework;
using System.Configuration;
using MySystem.Service.Domain;
using MySystem.Test.BDDLogin;

namespace MySystem.Test.BDDMain
{
    [Binding]
    public class EditAccountTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["UsersDBCon"].ConnectionString;
        OperationStatusInfo operationStatusInfo = null;

        [When("User try to edit account by (.*) and (.*) and (.*) and (.*) and (.*)")]
        public async Task EditAccount(int id, string lastName, string firstName, string secondName, int idUser)
        {
            try
            {
                AccountDTO accountDTO = new AccountDTO(id,lastName,firstName,secondName,idUser);
                operationStatusInfo = await this.mainClient.UpdateAccountAsync(accountDTO);
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
