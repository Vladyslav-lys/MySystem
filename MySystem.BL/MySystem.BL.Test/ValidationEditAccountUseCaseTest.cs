using NUnit.Framework;
using MySystem.BL.Contract;
using MySystem.BL.Rules;
using MySystem.DAL.Entities;
using System.Threading.Tasks;
using System;

namespace MySystem.BL.Test
{
    [TestFixture]
    public class ValidationEditAccountUseCaseTest
    {
        [TestCase]
        public void LastNameCorrected()
        {
            IUpdateAccountValidationRule updateAccountValidationRule = new UpdateAccountValidationRule();
            ValidResult v1 = updateAccountValidationRule.ValidateLastName("somthing");
            Assert.IsTrue(v1.GetError().Length == 0);
        }

        [TestCase]
        public void LastNameNotCorrected()
        {
            IUpdateAccountValidationRule updateAccountValidationRule = new UpdateAccountValidationRule();
            ValidResult v1 = updateAccountValidationRule.ValidateLastName("ыфв_");
            ValidResult v2 = updateAccountValidationRule.ValidateLastName("");
            ValidResult v3 = updateAccountValidationRule.ValidateLastName("somthing23");
            Assert.IsTrue(v1.GetError().Length > 0);
            Assert.IsTrue(v2.GetError().Length > 0);
            Assert.IsTrue(v3.GetError().Length > 0);
        }

        [TestCase]
        public void FirstNameCorrected()
        {
            IUpdateAccountValidationRule updateAccountValidationRule = new UpdateAccountValidationRule();
            ValidResult v1 = updateAccountValidationRule.ValidateLastName("somthing");
            Assert.IsTrue(v1.GetError().Length == 0);
        }

        [TestCase]
        public void FirstNameNotCorrected()
        {
            IUpdateAccountValidationRule updateAccountValidationRule = new UpdateAccountValidationRule();
            ValidResult v1 = updateAccountValidationRule.ValidateFirstName("ыфв_");
            ValidResult v2 = updateAccountValidationRule.ValidateFirstName("");
            ValidResult v3 = updateAccountValidationRule.ValidateFirstName("somthing23");
            Assert.IsTrue(v1.GetError().Length > 0);
            Assert.IsTrue(v2.GetError().Length > 0);
            Assert.IsTrue(v3.GetError().Length > 0);
        }

        [TestCase]
        public void SecondNameCorrected()
        {
            IUpdateAccountValidationRule updateAccountValidationRule = new UpdateAccountValidationRule();
            ValidResult v1 = updateAccountValidationRule.ValidateLastName("somthing");
            Assert.IsTrue(v1.GetError().Length == 0);
        }

        [TestCase]
        public void SecondNameNotCorrected()
        {
            IUpdateAccountValidationRule updateAccountValidationRule = new UpdateAccountValidationRule();
            ValidResult v1 = updateAccountValidationRule.ValidateSecondName("ыфв_");
            ValidResult v2 = updateAccountValidationRule.ValidateSecondName("");
            ValidResult v3 = updateAccountValidationRule.ValidateSecondName("somthing23");
            Assert.IsTrue(v1.GetError().Length > 0);
            Assert.IsTrue(v2.GetError().Length > 0);
            Assert.IsTrue(v3.GetError().Length > 0);
        }
    }
}
