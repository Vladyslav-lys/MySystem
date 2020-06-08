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
    public class AddNotesUseCaseTest
    {
        private string topic = "e";
        private string text = "fg";
        private DateTime date = new DateTime(2019, 11, 11);
        private byte[] image = new byte[0];
        private int idAccount = 2;

        [TestCase]
        public void AddNotesUseCaseEqualTest()
        {
            AddNotesRequest addNotesRequest = new AddNotesRequest(topic, text, date, image, idAccount);

            IUnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory();
            IUnitOfWork unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            unitOfWork.GetNotesFromDatabase();
            IActivityFactory activityFactory = new ActivityFactory(unitOfWork, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            AddNotesResponse addNotesResponse = useCaseFactory.CreateAddNotesUseCase().Execute(addNotesRequest);

            Assert.AreEqual(addNotesResponse.Notes[2].Topic, topic);
            Assert.AreEqual(addNotesResponse.Notes[2].Text, text);
            Assert.AreEqual(addNotesResponse.Notes[2].Date, date);
            Assert.AreEqual(addNotesResponse.Notes[2].Image, image);
        }
    }
}
