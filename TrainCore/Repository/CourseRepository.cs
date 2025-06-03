using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using DomainTrain.IRepository;
using DomainTrain.model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DomainTrain.Repository
{
    public class CourseRepository : ICourse
    {
        private MyDbContext _context;

        public CourseRepository(MyDbContext context)
        {
            _context = context;
        }


        public bool Add(Course model)
        {
            _context.Add(model);
            return true;
        }

        public bool Delete(Course model)
        {
            _context.Remove(model);
            return true;

        }

        public Course GetById(Guid id)
        {
            var models = _context.Courses.FirstOrDefault(x => x.id == id);
            return models;
        }

        public async Task<bool> IsExistById(Guid id)
        {
            var models =await _context.Courses.AnyAsync(x => x.id == id);
            return models;
        }

        public bool IsHasCourseRegirestion(Guid id)
        {
            return _context.Courses.Any(x => x.id == id && x.registration.Count > 0);
        }

        public async Task<List<Course>> GetlistAsync(Expression<Func<Course, bool>> contitions=null, int skip = 0, int pageSize = 10, string orderBy = "title", string orderType = "asc")
        {
            var query = buildQuery(contitions);

            //order
            if (orderType == "desc")
                query = query.OrderByDescending(orderCourse(orderBy));
            else
                query = query.OrderBy(orderCourse(orderBy));

            //pagging
            query = query.Skip(skip).Take(pageSize);

            return await query.ToListAsync();
        }


        public int GetlistCount(Expression<Func<Course, bool>> contitions = null)
        {
            var query = buildQuery(contitions);
            return query.Count();
        }

        private IQueryable<Course> buildQuery(Expression<Func<Course, bool>> contitions = null)
        {
            var query = _context.Courses.AsQueryable();

            //filter
            if (contitions != null)
            {
                query = query.Where(contitions);
            }

            return query;
        }

        private Expression<Func<Course,object>> orderCourse(string orderBy)
        {
            switch (orderBy.ToLower())
            {
                case "title": return x => x.title;
                case "category": return x => x.category;
                case "description": return x => x.description;
                case "work_day": return x => x.work_day;
                case "reg_start_date": return x => x.reg_start_date;
                case "reg_end_date": return x => x.reg_end_date;
                default: return x => x.id;
            }
        }

        public bool update(Course model)
        {
            _context.Update(model);
            return true;
        }
    }
}
