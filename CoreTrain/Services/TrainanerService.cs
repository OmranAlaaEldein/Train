using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core_engtraining.IAppServices;
using CoreTrain.Dto;
using DomainTrain;
using DomainTrain.model;
using LinqKit;

namespace Core_engtraining.Services
{
    public class TrainanerService : ITrainanerService
    {
        private IUnitOfWork _unitofwork;
        private IMapper _mapper;
        public TrainanerService(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }


        public Trainer_Dto GetTrainanerById(Guid id)
        {
            var result= _unitofwork.TrainerRepo.GetById(id);
            var mapModel = _mapper.Map<Trainer,Trainer_Dto>(result);
            
            return mapModel;
        }

        public bool IsExistById(Guid id)
        {
            var result = _unitofwork.TrainerRepo.IsExistById(id);
            return result;
        }

        public bool IsExistByName(string name, Guid? id = null)
        {
            name = name.ToLower().Trim();
            var result = _unitofwork.TrainerRepo.Getlist(x => x.name.Trim().ToLower() == name && (!id.HasValue || id != x.Id), pageSize: -1);

            return result.Count > 0;
        }

        public Trainer? GetTrainerByUserName(string name)
        {
            name = name.ToLower().Trim();
            var result = _unitofwork.TrainerRepo.Getlist(x => x.Username.Trim().ToLower()==name);

            return result.FirstOrDefault();
        }

        public bool IsHaseCourse(Guid id)
        {
            return _unitofwork.TrainerRepo.IsHasCourse(id);
        }

        public List<Trainer_Dto> GetAllTrainner(List<Filter> filters, int pageSize = 10, int pageNumber = 1, string orderBy = "title", string orderType = "asc")
        {
            int skip = (pageNumber - 1) * pageSize;
            var conditions = buildConditions(filters);

            var result= _unitofwork.TrainerRepo.Getlist(conditions, skip: skip, pageSize: pageSize, orderBy, orderType);
            var mapModel = _mapper.Map<List<Trainer>, List<Trainer_Dto>>(result);

            return mapModel;
        }

        public int GetAllTrainCount(List<Filter> filters)
        {
            var conditions = buildConditions(filters);

            return _unitofwork.TrainerRepo.GetlistCount(conditions);
        }

        private ExpressionStarter<Trainer> buildConditions(List<Filter> filters)
        {
           
            var conditions = PredicateBuilder.True<Trainer>();
            if (filters.Count == 0)
                return conditions;
            foreach (var item in filters)
            {
                switch (item.field.ToLower())
                {
                    case "name":
                        switch (item.operation)
                        {
                            case "=":
                                conditions = conditions.And(x => x.name == item.value);
                                break;
                            case "!=":
                                conditions = conditions.And(x => x.name != item.value);
                                break;
                            case "contian":
                                conditions = conditions.And(x => x.name.Contains(item.value));
                                break;
                            case "startwith":
                                conditions = conditions.And(x => x.name.StartsWith(item.value));
                                break;
                            case "endwith":
                                conditions = conditions.And(x => x.name.EndsWith(item.value));
                                break;
                            case "empty":
                                conditions = conditions.And(x => string.IsNullOrEmpty(x.name));
                                break;
                        }

                        break;
                    case "bio":
                        switch (item.operation)
                        {
                            case "=":
                                conditions = conditions.And(x => x.bio == item.value);
                                break;
                            case "!=":
                                conditions = conditions.And(x => x.bio != item.value);
                                break;
                            case "contian":
                                conditions = conditions.And(x => x.bio.Contains(item.value));
                                break;
                            case "startwith":
                                conditions = conditions.And(x => x.bio.StartsWith(item.value));
                                break;
                            case "endwith":
                                conditions = conditions.And(x => x.bio.EndsWith(item.value));
                                break;
                            case "empty":
                                conditions = conditions.And(x => string.IsNullOrEmpty(x.bio));
                                break;
                        }
                        break;
                    case "specialization":
                        switch (item.operation)
                        {
                            case "=":
                                conditions = conditions.And(x => x.specialization == item.value);
                                break;
                            case "!=":
                                conditions = conditions.And(x => x.specialization != item.value);
                                break;
                            case "contian":
                                conditions = conditions.And(x => x.specialization.Contains(item.value));
                                break;
                            case "startwith":
                                conditions = conditions.And(x => x.specialization.StartsWith(item.value));
                                break;
                            case "endwith":
                                conditions = conditions.And(x => x.specialization.EndsWith(item.value));
                                break;
                            case "empty":
                                conditions = conditions.And(x => string.IsNullOrEmpty(x.specialization));
                                break;
                        }
                        break;
                }
            }

            return conditions;
        }
        
        
        public bool AddTrainaner(Trainer_Dto newTrainaner)
        {
            var mapModel = _mapper.Map<Trainer_Dto, Trainer>(newTrainaner);

            mapModel = new Trainer()
            {
              Username= "omar",
              bio= "ite",
              specialization= "ite",
              name= "omar",
              password= "123"
             };
            var result = _unitofwork.TrainerRepo.Add(mapModel);
            _unitofwork.Save();

            return result;
        }

        public bool DeleteTrainaner(Guid id)
        {
            var model = _unitofwork.TrainerRepo.GetById(id);

            var result = _unitofwork.TrainerRepo.Delete(model);
            _unitofwork.Save();

            return result;
        }

        public bool UpdateTrainaner(Guid id, Trainer_Dto updated)
        {
            var model = _unitofwork.TrainerRepo.GetById(id);
            _mapper.Map<Trainer_Dto, Trainer>(updated, model);

            var result = _unitofwork.TrainerRepo.update(model);
            _unitofwork.Save();

            return result;
        }
    }
}
