using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainTrain.model;

namespace DomainTrain.IRepository
{
    public interface ICourse
    {
        public Course GetById(Guid id);
        public Task<bool> IsExistById(Guid id);
        public bool IsHasCourseRegirestion(Guid id);

        public Task<List<Course>> GetlistAsync(Expression<Func<Course, bool>> contitions = null, int skip = 0, int pageSize = 10, string orderBy = "title", string orderType = "asc");
        public int GetlistCount(Expression<Func<Course, bool>> contitions = null);

        public bool Add(Course model);
        public bool update(Course model);
        public bool Delete(Course model);
    }
}
