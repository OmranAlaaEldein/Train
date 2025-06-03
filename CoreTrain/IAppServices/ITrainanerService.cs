using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoreTrain.Dto;
using DomainTrain.model;


namespace Core_engtraining.IAppServices
{
  
  public interface ITrainanerService
    {
        public List<Trainer_Dto> GetAllTrainner(List<Filter> filters, int pageSize = 10, int pageNumber = 1, string orderBy = "title", string orderType = "asc");
        public int GetAllTrainCount(List<Filter> filters);
        
        public Trainer_Dto GetTrainanerById(Guid id);
        public bool IsExistById(Guid id);
        public bool IsExistByName(string name, Guid? id=null);
        public bool IsHaseCourse(Guid id);
        public Trainer? GetTrainerByUserName(string name);

        public bool AddTrainaner(Trainer_Dto newTrainaner);
        public bool UpdateTrainaner(Guid id, Trainer_Dto updatedActivity);
        public bool DeleteTrainaner(Guid id);
    }
}
