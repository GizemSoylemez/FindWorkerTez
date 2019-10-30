using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FindWorker.Data.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void Post(T Entity); // add
        void Put(T Entity); //update
        void Delete(T Entity);
        void Save();
    }
}
