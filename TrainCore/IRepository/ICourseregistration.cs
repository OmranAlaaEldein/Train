using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DomainTrain.model;

namespace DomainTrain.IRepository
{
    public interface ICourseregistration
    {
        public Courseregistration GetById(Guid id);
        public List<Courseregistration> Getlist(Expression<Func<Courseregistration, bool>> contitions=null);
                
        public bool Add(Courseregistration model);
        public bool update(Courseregistration model);
        public bool Delete(Courseregistration model);
    }
}
