using System;
using System.Collections.Generic;
using System.Text;

namespace DomainTrain.Repository
{
    internal class JobRepository
    {
        public JobRepository(MyDbContext context)
        {
            Context = context;
        }

        public MyDbContext Context { get; }
    }
}
