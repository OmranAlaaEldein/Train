using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DomainTrain.IRepository;
using DomainTrain.model;

namespace DomainTrain.Repository
{
    public class ActivityRepositry : IActivity
    {
        private MyDbContext _context;

        public ActivityRepositry(MyDbContext context)
        {
            _context = context;
        }

        public bool Add(Activity model)
        {
            _context.Add(model);
            return true;

        }

        public bool Delete(Activity model)
        {
            _context.Remove(model);
            return true;

        }

        public Activity? GetById(Guid id)
        {
            return _context.Activities.FirstOrDefault(x => x.id == id);
        }

        public bool IsExistById(Guid id)
        {
           return _context.Activities.Any(x=>x.id==id);
        }

        public List<Activity> Getlist(Expression<Func<Activity, bool>> contition=null)
        {
            var query = _context.Activities.AsQueryable();
            if (contition != null)
            {
                query = query.Where(contition);
            }

            return query.ToList();
        }

        public bool update(Activity model)
        {
            _context.Update(model);
            return true;
        }
    }
}
