using System;
using System.Collections.Generic;
using CoreTrain.Dto;
using DomainTrain.model;

namespace Core_engtraining.IAppServices
{
    public interface IActivityService
    {
        public List<Activity> GetAllActivities();
        public Activity GetActivityById(Guid id);
        public bool IsExistById(Guid id);
        public bool AddActivity(Activity_Dto newActivity);
        public bool UpdateActivity(Guid id, Activity_Dto updatedActivity);
        public bool DeleteActivity(Guid id);
    }
}