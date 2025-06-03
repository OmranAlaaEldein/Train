using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DomainTrain.IRepository;
using DomainTrain.model;

namespace DomainTrain.Repository
{
    public class CourseregistrationRepository : ICourseregistration
    {
        private MyDbContext _context;

        public CourseregistrationRepository(MyDbContext context)
        {
            _context = context;
        }


        public bool Add(Courseregistration model)
        {
            _context.Add(model);
            return true;
        }

        public bool Delete(Courseregistration model)
        {
            _context.Remove(model);
            return true;

        }

        public Courseregistration GetById(Guid id)
        {
            var models = _context.Courseregistrations.FirstOrDefault(x => x.id == id);
            return models;

        }

        public List<Courseregistration> Getlist(Expression<Func<Courseregistration, bool>> contitions=null)
        {
            var query = _context.Courseregistrations.AsQueryable();
            if (contitions != null)
            {
                query = query.Where(contitions);
            }

            return query.ToList();
        }

        public bool update(Courseregistration model)
        {
            _context.Update(model);
            return true;
        }
    }
}
