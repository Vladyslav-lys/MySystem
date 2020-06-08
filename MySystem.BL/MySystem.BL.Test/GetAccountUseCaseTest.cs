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
    public class GetAccountUseCaseTest
    {
        private int idUser = 10;
        private string lastName = "Lysenko";
        private string firstName = "Vladyslav";
        private string secondName = "Urievich";

        [TestCase]
        public void GetAccountUseCaseEqualTest()
        {
            GetAccountRequest getAccountRequest = new GetAccountRequest(idUser);

            IUnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory();
            IUnitOfWork unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            unitOfWork.GetAccountsFromDatabase();
            IActivityFactory activityFactory = new ActivityFactory(unitOfWork, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetAccountResponse getAccountResponse = useCaseFactory.CreateGetAccountUseCase().Execute(getAccountRequest);

            Assert.AreEqual(getAccountResponse.Account.LastName, lastName);
            Assert.AreEqual(getAccountResponse.Account.FirstName, firstName);
            Assert.AreEqual(getAccountResponse.Account.SecondName, secondName);
        }

        [TestCase]
        public void GetAccountUseCaseNotEqualTest()
        {
            Exception exception = null;

            try
            {
                GetAccountRequest getAccountRequest = new GetAccountRequest(1);

                IUnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory();
                IUnitOfWork unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
                unitOfWork.GetAccountsFromDatabase();
                IActivityFactory activityFactory = new ActivityFactory(unitOfWork, new ValidationRuleFactory());
                IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
                GetAccountResponse getAccountResponse = useCaseFactory.CreateGetAccountUseCase().Execute(getAccountRequest);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.AreEqual(exception.Message, "The account is not found!");
        }
    }
}
