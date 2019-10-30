using FindWorker.Data.Abstract;
using FindWorker.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindWorker.Data.Concrete.Ef
{
    public class EfHobbyRepository:EfGenericRepository<Hobby>, IHobbyRepository
    {
        public EfHobbyRepository(FindWorkersTezContext context) : base(context)
        {

        }

        public FindWorkersTezContext EContext
        {
            get { return context as FindWorkersTezContext; }
        }
    }
}
