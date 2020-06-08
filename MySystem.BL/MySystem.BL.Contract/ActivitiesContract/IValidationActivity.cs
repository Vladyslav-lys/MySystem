using System;
using System.Collections.Generic;
using System.Text;

namespace MySystem.BL.Contract
{
    public interface IValidationActivity<T>
    {
        void Validate(T request);
    }
}
