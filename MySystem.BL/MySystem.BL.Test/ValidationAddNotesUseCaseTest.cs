using NUnit.Framework;
using MySystem.BL.Contract;
using MySystem.BL.Rules;
using MySystem.DAL.Entities;
using System.Threading.Tasks;
using System;

namespace MySystem.BL.Test
{
    [TestFixture]
    public class ValidationAddNotesUseCaseTest
    {
        [TestCase]
        public void TopicCorrected()
        {
            IDataNotesValidationRule dataNotesValidationRule = new DataNotesValidationRule();
            ValidResult v1 = dataNotesValidationRule.ValidateTopic("fds");
            Assert.IsTrue(v1.GetError().Length == 0);
        }

        [TestCase]
        public void TopicNotCorrected()
        {
            IDataNotesValidationRule dataNotesValidationRule = new DataNotesValidationRule();
            ValidResult v1 = dataNotesValidationRule.ValidateTopic("");
            Assert.IsTrue(v1.GetError().Length > 0);
        }

        [TestCase]
        public void TextCorrected()
        {
            IDataNotesValidationRule dataNotesValidationRule = new DataNotesValidationRule();
            ValidResult v1 = dataNotesValidationRule.ValidateText("fds");
            Assert.IsTrue(v1.GetError().Length == 0);
        }

        [TestCase]
        public void TextNotCorrected()
        {
            IDataNotesValidationRule dataNotesValidationRule = new DataNotesValidationRule();
            ValidResult v1 = dataNotesValidationRule.ValidateText("");
            Assert.IsTrue(v1.GetError().Length > 0);
        }

        [TestCase]
        public void DateCorrected()
        {
            IDataNotesValidationRule dataNotesValidationRule = new DataNotesValidationRule();
            ValidResult v1 = dataNotesValidationRule.ValidateDate(DateTime.Now);
            Assert.IsTrue(v1.GetError().Length == 0);
        }
    }
}
