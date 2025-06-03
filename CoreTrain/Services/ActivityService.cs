using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Core_engtraining.IAppServices;
using CoreTrain.Dto;
using DomainTrain;
using DomainTrain.model;
using Microsoft.EntityFrameworkCore;

namespace Core_engtraining.Services

{
    public class ActivityService : IActivityService
    {
        private IUnitOfWork _unitofwork;
        private IMapper _mapper;
        public ActivityService(IUnitOfWork unitofwork, IMapper mapper) {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }

        public List<Activity> GetAllActivities()
        {
            return _unitofwork.activeRepo.Getlist();
        }

        public Activity GetActivityById(Guid id)
        {
            return _unitofwork.activeRepo.GetById(id);
        }

        public bool IsExistById(Guid id)
        {
            return _unitofwork.activeRepo.IsExistById(id);
        }

        public bool AddActivity(Activity_Dto newActivity)
        {
            var mapModel=_mapper.Map<Activity_Dto, Activity>(newActivity);
            
            var result= _unitofwork.activeRepo.Add(mapModel);
            _unitofwork.Save();

            return result;
        }

        public bool UpdateActivity(Guid id, Activity_Dto updatedActivity)
        {
            var model= _unitofwork.activeRepo.GetById(id);
            _mapper.Map<Activity_Dto, Activity>(updatedActivity,model);

            var result = _unitofwork.activeRepo.update(model);
            _unitofwork.Save();

            return result;
        }

        public bool DeleteActivity(Guid id)
        {
            var model = _unitofwork.activeRepo.GetById(id);

            var result = _unitofwork.activeRepo.Delete(model);
            _unitofwork.Save();

            return result;
        }
    }
}