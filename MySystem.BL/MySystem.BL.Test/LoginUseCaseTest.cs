using NUnit.Framework;
using MySystem.BL.Contract;
using MySystem.BL.Rules;
using MySystem.BL.DomainEvents;
using MySystem.DAL.Entities;
using MySystem.DAL.Contract;
using MySystem.DAL.Repositories;
using MySystem.BL.Activities;
using MySystem.BL.UseCases;
using System.Threading.Tasks;
using System;

namespace MySystem.BL.Test
{
    [TestFixture]
    public class LoginUseCaseTest
    {
        private string login = "z";
        private string password = "pas";

        [TestCase]
        public void LoginUseCaseEqualTest()
        {
            GetUserRequest getUserRequest = new GetUserRequest(login, password);

            IUnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory();
            IUnitOfWork unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            unitOfWork.GetUsersFromDatabase();
            IActivityFactory activityFactory = new ActivityFactory(unitOfWork, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetUserResponse getUserResponse = useCaseFactory.CreateLoginUseCase().Execute(getUserRequest);

            Assert.AreEqual(getUserResponse.User.Login, login);
            Assert.AreEqual(getUserResponse.User.Password, password);
        }

        [TestCase]
        public void LoginUseCaseNotEqualTest()
        {
            Exception exception = null;

            try
            {
                IUnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory();
                IUnitOfWork unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
                unitOfWork.GetUsersFromDatabase();
                IActivityFactory activityFactory = new ActivityFactory(unitOfWork, new ValidationRuleFactory());
                IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
                GetUserRequest getUserRequest = new GetUserRequest("re", "f");
                GetUserResponse getUserResponse = useCaseFactory.CreateLoginUseCase().Execute(getUserRequest);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.AreEqual(exception.Message, "The user is not found! Please, check out login or password");
        }
    }
}
