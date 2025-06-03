using System;
using System.Collections.Generic;
using System.Text;
using CoreTrain.Dto;
using DomainTrain.model;

namespace Core_engtraining.IAppServices
{
    public interface IJobService
    {
        public List<Job> GetJobs(int pageSize = 10, int pageNumber = 1, string orderBy = "title", string orderType = "asc");
        public Job GetJobById(Guid id);
        public bool IsExistById(Guid id);
        public bool AddJob(Job_Dto newJob);
        public bool UpdateJob(Guid id, Job_Dto updatedJob);
        public bool DeleteJob(Guid id);
    }
}
