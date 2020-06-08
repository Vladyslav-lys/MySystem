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

namespace MySystem.Test.BDDLogin
{
    [Binding]
    public class EnterTest : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["UsersDBCon"].ConnectionString;
        UserDTO userDTO = null;

        [When("User try to enter by (.*) and (.*) through Client")]
        public async Task EnterClient(string login, string password)
        {
            try
            {
                userDTO = await this.mainClient.EnterAsync(login, password);//"z", "pas"
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }
    }
}
