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
    public class EditAccountUseCaseTest
    {
        private int id = 2;
        private string lastName = "Lysenko";
        private string firstName = "Vladyslav";
        private string secondName = "Urievich";
        private byte[] photo = new byte[0];

        [TestCase]
        public void EditAccountUseCaseEqualTest()
        {
            EditAccountRequest editAccountRequest = new EditAccountRequest(id, lastName, firstName, secondName, photo);

            IUnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory();
            IUnitOfWork unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            unitOfWork.GetAccountsFromDatabase();
            IActivityFactory activityFactory = new ActivityFactory(unitOfWork, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            EditAccountResponse editAccountResponse = useCaseFactory.CreateEditAccountUseCase().Execute(editAccountRequest);

            Assert.AreEqual(editAccountResponse.Account.LastName, lastName);
            Assert.AreEqual(editAccountResponse.Account.FirstName, firstName);
            Assert.AreEqual(editAccountResponse.Account.SecondName, secondName);
        }

        [TestCase]
        public void EditAccountUseCaseNotEqualTest()
        {
            Exception exception = null;

            try
            {
                EditAccountRequest editAccountRequest = new EditAccountRequest(10, lastName, firstName, secondName, photo);

                IUnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory();
                IUnitOfWork unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
                unitOfWork.GetAccountsFromDatabase();
                IActivityFactory activityFactory = new ActivityFactory(unitOfWork, new ValidationRuleFactory());
                IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
                EditAccountResponse editAccountResponse = useCaseFactory.CreateEditAccountUseCase().Execute(editAccountRequest);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.AreEqual(exception.Message, "The account is not updated and not found!");
        }
    }
}
