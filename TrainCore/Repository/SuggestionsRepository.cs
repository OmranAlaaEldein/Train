using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DomainTrain.IRepository;
using DomainTrain.model;

namespace DomainTrain.Repository
{
    internal class SuggestionsRepository:ISuggestions
    {
        private MyDbContext context;

        public SuggestionsRepository(MyDbContext context)
        {
            this.context = context;
        }

        public bool Add(Suggestions model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Suggestions model)
        {
            throw new NotImplementedException();
        }

        public Suggestions GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Suggestions> GetList(Expression<Func<Suggestions, bool>> contition)
        {
            throw new NotImplementedException();
        }

        public bool update(Suggestions model)
        {
            throw new NotImplementedException();
        }
    }
}
