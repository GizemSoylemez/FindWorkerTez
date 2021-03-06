﻿using FindWorker.Data.Abstract;
using FindWorker.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FindWorker.Data.Concrete.Ef
{
    public class EfRoleRepository:EfGenericRepository<Role>, IRoleRepository
    {
        public EfRoleRepository(FindWorkersTezContext context) : base(context)
        {

        }

        public FindWorkersTezContext EContext
        {
            get { return context as FindWorkersTezContext; }
        }
    }
}
