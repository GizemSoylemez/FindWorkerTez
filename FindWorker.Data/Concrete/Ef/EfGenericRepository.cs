using FindWorker.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FindWorker.Data.Concrete.Ef
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext context;

        public EfGenericRepository(DbContext ctx)
        {
            context = ctx;
        }

        public void Delete(T Entity)
        {
            context.Set<T>().Remove(Entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }


        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public void Post(T Entity)
        {
            context.Set<T>().Add(Entity);
        }

        public void Put(T Entity)
        {
            context.Entry(Entity).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        
    }
}
