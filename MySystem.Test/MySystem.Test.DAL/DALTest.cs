using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using MySystem.DAL.Contract;
using MySystem.DAL.Repositories;
using NUnit.Framework;
using System.Configuration;

namespace MySystem.Test.DAL
{
    [Binding]
    public class DALTest
    {
        private IUnitOfWorkCreator unitOfWorkCreator;
        private IUnitOfWork unitOfWork;
        private Exception ex = null;

        [Given("Set right unit Of work"), Scope(Scenario = "Get right users from database")]
        public void CreateRightUserContextTest()
        {
            string constring = ConfigurationManager.ConnectionStrings["UsersDBCon"].ConnectionString;
            string tableName = ConfigurationManager.AppSettings["UserTable"];

            unitOfWorkCreator = new UnitOfWorkCreator(constring, tableName);
            unitOfWork = unitOfWorkCreator.CreateUnitOfWork();
        }

        [Given("Set false unit Of work for wrong table"), Scope(Scenario = "Get false users connection from database")] 
        public void CreateFalseTableUserContextTest()
        {
            string constring = ConfigurationManager.ConnectionStrings["UsersDBCon"].ConnectionString;
            string tableName = "sad";

            unitOfWorkCreator = new UnitOfWorkCreator(constring, tableName);
            unitOfWork = unitOfWorkCreator.CreateUnitOfWork();
        }

        [Given("Set false unit Of work for wrong connection"), Scope(Scenario = "Get false users table from database")] 
        public void CreateFalseConnectionUserContextTest()
        {
            string constring = "dsa";
            string tableName = ConfigurationManager.AppSettings["UserTable"];

            unitOfWorkCreator = new UnitOfWorkCreator(constring, tableName);
            
        }

        [When("I try to get users from database")]
        public void GetUsersFromDatabaseTest()
        {
            try
            {
                unitOfWork = unitOfWorkCreator.CreateUnitOfWork();
            }
            catch (Exception ex)
            {
                this.ex = ex;
            }
        }

        [Then("Get the right result"), Scope(Scenario = "Get right users from database")]
        public void RightResultOfGettingUsersFormDatabase()
        {
            Assert.IsTrue(this.ex == null);
        }

        [Then("Get the false result")]
        public void FalseResultOfGettingUsersFromDatabase()
        {
            Assert.IsTrue(this.ex != null);
        }
    }
}