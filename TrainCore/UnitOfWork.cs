using System;
using System.Collections.Generic;
using System.Text;
using DomainTrain.IRepository;
using DomainTrain.Repository;

namespace DomainTrain
{
    public class UnitOfWork :IUnitOfWork
    {
        private MyDbContext _context;

        public IActivity activeRepo { get ; set; }
        public IActiveuser activeUserRepo { get; set; }
        public ICourse CourseRepo { get; set; }
        public ICourseregistration CourseregistrationRepo { get; set; }
        public IJob JobRepo { get; set; }
        public ISuggestions SuggestionsRepo { get; set; }
        public ITrainer TrainerRepo { get; set; }

        public UnitOfWork(MyDbContext context)
        {
            _context = context;
            activeRepo = new ActivityRepositry(_context);
            activeUserRepo = new ActiveuserRepositry(_context);
            CourseregistrationRepo = new CourseregistrationRepository(_context);
            CourseRepo = new CourseRepository(_context);
            SuggestionsRepo = new SuggestionsRepository(_context);
            TrainerRepo = new TrainerRepository(_context);

        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
