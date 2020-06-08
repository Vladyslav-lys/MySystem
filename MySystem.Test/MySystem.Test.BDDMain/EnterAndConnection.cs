﻿using System;
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
    public class EnterAndConnection : TestBase
    {
        string constring = ConfigurationManager.ConnectionStrings["UsersDBCon"].ConnectionString;
        UserDTO userDTO = null;

        [Given("User try to connect the server")]
        public void Connect()
        {
            try
            {
                this.mainClient.ConnectAsync();
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }

        [When("it will be successful")]
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

        [Then("it will be successful")]
        public void ResultRight()
        {
            Assert.IsTrue(this.ex == null);
        }

        [Then("it will be failed")]
        public void ResultWrong()
        {
            Assert.IsFalse(this.ex == null);
        }
    }
}
