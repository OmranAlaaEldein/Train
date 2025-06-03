using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using DomainTrain.model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DomainTrain.IRepository;

namespace DomainTrain.Repository
{
    public class TrainerRepository:ITrainer
    {
        private MyDbContext _context;

        public TrainerRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<Trainer> Getlist(Expression<Func<Trainer, bool>> contitions = null, int skip = 0, int pageSize = 10, string orderBy = "title", string orderType = "asc")
        {
            var query = buildQuery(contitions);

            //order
            if (orderType == "desc")
                query = query.OrderByDescending(orderCourse(orderBy));
            else
                query = query.OrderBy(orderCourse(orderBy));

            //pagging
            if(pageSize>0)
                query = query.Skip(skip).Take(pageSize);

            return  query.ToList();
        }


        public int GetlistCount(Expression<Func<Trainer, bool>> contitions = null)
        {
            var query = buildQuery(contitions);
            return query.Count();
        }

        private IQueryable<Trainer> buildQuery(Expression<Func<Trainer, bool>> contitions = null)
        {
            var query = _context.Trainers.AsNoTracking().Include(x=>x.Course).AsQueryable();

            //filter
            if (contitions != null)
            {
                query = query.Where(contitions);
            }

            return query;
        }

        private Expression<Func<Trainer, object>> orderCourse(string orderBy)
        {
            switch (orderBy.ToLower())
            {
                case "name": return x => x.name;
                case "bio": return x => x.bio;
                case "specialization": return x => x.specialization;
                default: return x => x.Id;
            }
        }


        public bool Add(Trainer model)
        {
            _context.Add(model);
            return true;
        }

        public bool Delete(Trainer model)
        {
            _context.Remove(model);
            return true;

        }

        public bool update(Trainer model)
        {
            _context.Update(model);
            return true;
        }

        public Trainer GetById(Guid id)
        {
            return _context.Trainers.FirstOrDefault(x => x.Id == id);
        }

        public bool IsExistById(Guid id)
        {
            return _context.Trainers.Any(x => x.Id == id);
        }

        public bool IsHasCourse(Guid id)
        {
            return _context.Trainers.Any(x => x.Id == id && x.Course.Count>0);
        }
    }
}
