using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DomainTrain.model;

namespace DomainTrain.IRepository
{
    public interface IJob
    {
        public Job GetById(Guid id);
        public List<Job> GetList(Expression<Func<Job, bool>> contition);
        public bool Add(Job model);
        public bool update(Job model);
        public bool Delete(Job model);
        List<Job> Getlist();
        bool IsExistById(Guid id);
    }
}
