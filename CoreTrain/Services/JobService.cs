using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Core_engtraining.IAppServices;
using CoreTrain.Dto;
using DomainTrain;
using DomainTrain.model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Core_engtraining.Services
{
    public class JobService : IJobService
    {
        private IUnitOfWork _unitofwork;
        private IMapper _mapper;
        public JobService(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }

        public List<Job> GetAllJobs()
        {
            return _unitofwork.JobRepo.Getlist();
        }

        public Job GetJobById(Guid id)
        {
            return _unitofwork.JobRepo.GetById(id);
        }

        public bool IsExistById(Guid id)
        {
            return _unitofwork.JobRepo.IsExistById(id);
        }

        public bool AddJob(Job_Dto newJob)
        {
            var mapModel = _mapper.Map<Job_Dto, Job>(newJob);

            var result = _unitofwork.JobRepo.Add(mapModel);
            _unitofwork.Save();

            return result;
        }

        public bool UpdateJob(Guid id, Job_Dto updatedJob)
        {
            var model = _unitofwork.JobRepo.GetById(id);
            _mapper.Map<Job_Dto, Job>(updatedJob, model);

            var result = _unitofwork.JobRepo.update(model);
            _unitofwork.Save();

            return result;
        }

        public bool DeleteJob(Guid id)
        {
            var model = _unitofwork.JobRepo.GetById(id);

            var result = _unitofwork.JobRepo.Delete(model);
            _unitofwork.Save();

            return result;
        }

        public List<Job> GetJobs(int pageSize = 10, int pageNumber = 1, string orderBy = "title", string orderType = "asc")
        {
            throw new NotImplementedException();
        }


        }
    }