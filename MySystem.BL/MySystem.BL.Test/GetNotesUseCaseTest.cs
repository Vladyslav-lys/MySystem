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
    public class GetNotesUseCaseTest
    {
        private int idAccount = 2;
        private string topic = "tr";
        private string text = "df";
        private DateTime date = new DateTime(2019, 11, 11);
        private byte[] image = new byte[0];

        [TestCase]
        public void GetNotesUseCaseEqualTest()
        {
            GetNotesRequest getNotesRequest = new GetNotesRequest(idAccount);

            IUnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory();
            IUnitOfWork unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            unitOfWork.GetNotesFromDatabase();
            IActivityFactory activityFactory = new ActivityFactory(unitOfWork, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            GetNotesResponse getNotesResponse = useCaseFactory.CreateGetNotesUseCase().Execute(getNotesRequest);

            Assert.AreEqual(getNotesResponse.Notes[0].Topic, this.topic);
            Assert.AreEqual(getNotesResponse.Notes[0].Text, this.text);
            Assert.AreEqual(getNotesResponse.Notes[0].Date, this.date);
            Assert.AreEqual(getNotesResponse.Notes[0].Image, this.image);
        }
    }
}
