using System;
using System.Collections.Generic;
using System.Text;
using DomainTrain.IRepository;

namespace DomainTrain
{
    public interface IUnitOfWork : IDisposable
    {

        IActivity activeRepo { get; set; }
        IActiveuser activeUserRepo { get; set; }
        ICourse CourseRepo { get; set; }
        ICourseregistration CourseregistrationRepo { get; set; }
        IJob JobRepo { get; set; }
        ISuggestions SuggestionsRepo { get; set; }
        ITrainer TrainerRepo { get; set; }
        public int Save();

    }
}
