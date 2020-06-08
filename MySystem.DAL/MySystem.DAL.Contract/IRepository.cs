using System;
using System.Collections.Generic;
using System.Text;

namespace MySystem.DAL.Contract
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        void GetNewAll();
        T Find(T item);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
