using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using MySystem.DAL.Contract;
using MySystem.DAL.Repositories;
using NUnit.Framework;
using System.Configuration;
using MySystem.Client.Contract;
using MySystem.Client.Main;

namespace MySystem.Test.BDDLogin
{
    [Binding]
    public class ConnectionTest : TestBase
    {
        [Given("User try to connect the server")]
        public void Connect()
        {
            try
            {
                this.mainClient.ConnectAsync();
            }
            catch(Exception ex)
            {
                this.ex = ex;
            }
        }

        [When("it will be successful")]
        [When("User try to disconnect the server")]
        public void Disconnect()
        {
            try
            {
                this.mainClient.DisconnectAsync();
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
