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
    public class GetAccountTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["UsersDBCon"].ConnectionString;
        AccountDTO accountDTO = null;

        [When("User try to get account by (.*)")]
        public async Task GetAccount(int idUser)
        {
            try
            {
                accountDTO = await this.mainClient.ShowAccountAsync(idUser);//"z", "pas"
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
