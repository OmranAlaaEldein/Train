using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainTrain.IRepository;
using DomainTrain.model;

namespace DomainTrain.Repository
{
    public class ActiveuserRepositry :IActiveuser
    {
        private MyDbContext _context;

        public ActiveuserRepositry(MyDbContext context)
        {
            _context = context;
        }

        public bool Add(Activeuser model)
        {
            throw new NotImplementedException();
         
        }

        public bool Delete(Activeuser model)
        {
            throw new NotImplementedException();
            
        }

        public Activeuser GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Activeuser> Getlist(IQueryable<Activeuser> contitions)
        {
            throw new NotImplementedException();
        }

        public bool update(Activeuser model)
        {
            throw new NotImplementedException();
        }
    }
}
