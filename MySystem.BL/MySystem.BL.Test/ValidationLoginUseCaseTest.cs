using NUnit.Framework;
using MySystem.BL.Contract;
using MySystem.BL.Rules;
using MySystem.DAL.Entities;
using System.Threading.Tasks;
using System;

namespace MySystem.BL.Test
{
    [TestFixture]
    public class ValidationLoginUseCaseTest
    {
        [TestCase]
        public void LoginCorrected()
        {
            IEnterValidationRule enterValidationRule = new EnterValidationRule();
            ValidResult v1 = enterValidationRule.ValidateLogin("somthing");
            ValidResult v2 = enterValidationRule.ValidateLogin("somthing23");
            Assert.IsTrue(v1.GetError().Length == 0);
            Assert.IsTrue(v2.GetError().Length == 0);
        }

        [TestCase]
        public void LoginNotCorrected()
        {
            IEnterValidationRule enterValidationRule = new EnterValidationRule();
            ValidResult v1 = enterValidationRule.ValidateLogin("ыфв_");
            ValidResult v2 = enterValidationRule.ValidateLogin("");
            Assert.IsTrue(v1.GetError().Length > 0);
            Assert.IsTrue(v2.GetError().Length > 0);
        }

        [TestCase]
        public void PasswordCorrected()
        {
            IEnterValidationRule enterValidationRule = new EnterValidationRule();
            ValidResult v1 = enterValidationRule.ValidatePassword("somthing");
            ValidResult v2 = enterValidationRule.ValidatePassword("somthing23");
            Assert.IsTrue(v1.GetError().Length == 0);
            Assert.IsTrue(v2.GetError().Length == 0);
        }

        [TestCase]
        public void PasswordNotCorrected()
        {
            IEnterValidationRule enterValidationRule = new EnterValidationRule();
            ValidResult v1 = enterValidationRule.ValidatePassword("ыфв_");
            ValidResult v2 = enterValidationRule.ValidatePassword("");
            Assert.IsTrue(v1.GetError().Length > 0);
            Assert.IsTrue(v2.GetError().Length > 0);
        }
    }
}
