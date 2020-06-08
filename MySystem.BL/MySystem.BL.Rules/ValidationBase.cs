using System;
using System.Collections.Generic;
using System.Text;
using MySystem.BL.Contract;

namespace MySystem.BL.Rules
{
    public class ValidationBase
    {
        public ValidResult validResult;

        public ValidationBase()
        {
            validResult = new ValidResult();
        }
    }
}
