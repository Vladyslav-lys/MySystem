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
    public class TestBase
    {
        public IMainClient mainClient = new MainClient();
        public Exception ex = null;
    }
}
