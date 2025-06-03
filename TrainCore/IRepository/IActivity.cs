using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DomainTrain.model;

namespace DomainTrain.IRepository
{
    public interface IActivity
    {
        public Activity? GetById(Guid id);
        public bool IsExistById(Guid id);
        public List<Activity> Getlist(Expression<Func<Activity, bool>> contition =null);
        public bool Add(Activity model);
        public bool update(Activity model);
        public bool Delete(Activity model);
    }
}
