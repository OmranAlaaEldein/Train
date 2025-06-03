using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainTrain.model;

namespace DomainTrain.IRepository
{
    public interface IActiveuser
    {
        public Activeuser GetById(Guid id);
        public List<Activeuser> Getlist(IQueryable<Activeuser> contitions);
        public bool Add(Activeuser model);
        public bool update(Activeuser model);
        public bool Delete(Activeuser model);
    }
}
