using System;
using System.Collections.Generic;
using System.Text;

namespace MySystem.BL.Contract
{
    public interface IUseCase<T,R>
    {
        T Execute(R request);
    }
}
