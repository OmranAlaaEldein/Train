using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DomainTrain.model;

namespace DomainTrain.IRepository
{
    public interface ISuggestions
    {
        public Suggestions GetById(Guid id);
        public List<Suggestions> GetList(Expression<Func<Suggestions, bool>> contition);
        public bool Add(Suggestions model);
        public bool update(Suggestions model);
        public bool Delete(Suggestions model);
    }
}
