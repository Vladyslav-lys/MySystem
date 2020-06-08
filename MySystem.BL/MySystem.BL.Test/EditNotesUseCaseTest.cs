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
    public class EditNotesUseCaseTest
    {
        private int id = 2;
        private string topic = "tr";
        private string text = "df";
        private DateTime date = new DateTime(2019,11,11);
        private byte[] image = new byte[0];
        private int idAccount = 2;

        [TestCase]
        public void EditNotesUseCaseEqualTest()
        {
            EditNotesRequest editNotesRequest = new EditNotesRequest(id, topic, text, date, image, idAccount);

            IUnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory();
            IUnitOfWork unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
            unitOfWork.GetNotesFromDatabase();
            IActivityFactory activityFactory = new ActivityFactory(unitOfWork, new ValidationRuleFactory());
            IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
            EditNotesResponse editNotesResponse = useCaseFactory.CreateEditNotesUseCase().Execute(editNotesRequest);
            
            Assert.AreEqual(editNotesResponse.Notes[0].Topic, topic);
            Assert.AreEqual(editNotesResponse.Notes[0].Text, text);
            Assert.AreEqual(editNotesResponse.Notes[0].Date, date);
            Assert.AreEqual(editNotesResponse.Notes[0].Image, image);
        }

        [TestCase]
        public void EditNotesUseCaseNotEqualTest()
        {
            Exception exception = null;

            try
            {
                EditNotesRequest editNotesRequest = new EditNotesRequest(10, topic, text, date, image, idAccount);

                IUnitOfWorkFactory unitOfWorkFactory = new UnitOfWorkFactory();
                IUnitOfWork unitOfWork = unitOfWorkFactory.CreateUnitOfWork();
                unitOfWork.GetNotesFromDatabase();
                IActivityFactory activityFactory = new ActivityFactory(unitOfWork, new ValidationRuleFactory());
                IUseCaseFactory useCaseFactory = new UseCaseFactory(activityFactory);
                EditNotesResponse editNotesResponse = useCaseFactory.CreateEditNotesUseCase().Execute(editNotesRequest);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.AreEqual(exception.Message, "The notes are not updated and not found!");
        }
    }
}
