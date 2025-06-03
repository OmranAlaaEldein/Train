using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainTrain.model;

namespace DomainTrain.IRepository
{
    public interface ITrainer
    {
        public Trainer GetById(Guid id);
        public bool IsExistById(Guid id);
        public bool IsHasCourse(Guid id);
        public List<Trainer> Getlist(Expression<Func<Trainer, bool>> contitions = null, int skip = 0, int pageSize = 10, string orderBy = "name", string orderType = "asc");
        public int GetlistCount(Expression<Func<Trainer, bool>> contitions = null);
        
        public bool Add(Trainer model);
        public bool update(Trainer model);
        public bool Delete(Trainer model);
    }
}
