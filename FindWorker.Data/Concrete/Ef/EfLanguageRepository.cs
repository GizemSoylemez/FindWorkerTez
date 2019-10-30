using FindWorker.Data.Abstract;
using FindWorker.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindWorker.Data.Concrete.Ef
{
    public class EfLanguageRepository:EfGenericRepository<Language>, ILanguageRepository
    {
        public EfLanguageRepository(FindWorkersTezContext context) : base(context)
        {

        }

        public FindWorkersTezContext EContext
        {
            get { return context as FindWorkersTezContext; }
        }
    }
}
