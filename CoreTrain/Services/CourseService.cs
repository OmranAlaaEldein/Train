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
    public class CourseService: ICourseService
    {
        private IUnitOfWork _unitofwork;
        private IMapper _mapper;
        public CourseService(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }

        public async Task<List<Course_Dto>> GetAllCoursesAsync(List<Filter> filters, int pageSize = 10, int pageNumber = 1, string orderBy = "title", string orderType = "asc")
        {
            int skip = (pageNumber-1)*pageSize;
            var conditions = buildConditions(filters);

            var result= await _unitofwork.CourseRepo.GetlistAsync(conditions,skip: skip,pageSize:pageSize,orderBy,orderType);
            var mappRes = _mapper.Map<List<Course_Dto>>(result);

            return mappRes;
        }

        public int GetAllCoursesCount(List<Filter> filters)
        {
            var conditions = buildConditions(filters);

            return _unitofwork.CourseRepo.GetlistCount(conditions);
        }

        private ExpressionStarter<Course> buildConditions(List<Filter> filters)
        {
            var conditions = PredicateBuilder.True<Course>();
            if (filters.Count == 0)
                return conditions;
            foreach (var item in filters)
            {
                switch (item.field.ToLower())
                {
                    case "title":
                        switch (item.operation)
                        {
                            case "=":
                                conditions = conditions.And(x=>x.title==item.value);
                                break;
                            case "!=":
                                conditions = conditions.And(x => x.title != item.value); 
                                break;
                            case "contian":
                                conditions = conditions.And(x => x.title.Contains(item.value)); 
                                break;
                            case "startwith":
                                conditions = conditions.And(x => x.title.StartsWith(item.value));
                                break;
                            case "endwith":
                                conditions = conditions.And(x => x.title.EndsWith(item.value));
                                break;
                            case "empty":
                                conditions = conditions.And(x => string.IsNullOrEmpty(x.title)); 
                                break;
                        }
                        
                        break;
                    case "description":
                        switch (item.operation)
                        {
                            case "=":
                                conditions = conditions.And(x => x.title == item.value);
                                break;
                            case "!=":
                                conditions = conditions.And(x => x.title != item.value);
                                break;
                            case "contian":
                                conditions = conditions.And(x => x.title.Contains(item.value));
                                break;
                            case "startwith":
                                conditions = conditions.And(x => x.title.StartsWith(item.value));
                                break;
                            case "endwith":
                                conditions = conditions.And(x => x.title.EndsWith(item.value));
                                break;
                            case "empty":
                                conditions = conditions.And(x => string.IsNullOrEmpty(x.title));
                                break;
                        }
                        break;
                    case "category":
                        switch (item.operation)
                        {
                            case "=":
                                conditions = conditions.And(x => x.category == item.value);
                                break;
                            case "!=":
                                conditions = conditions.And(x => x.category != item.value);
                                break;
                            case "contian":
                                conditions = conditions.And(x => x.category.Contains(item.value));
                                break;
                            case "startwith":
                                conditions = conditions.And(x => x.category.StartsWith(item.value));
                                break;
                            case "endwith":
                                conditions = conditions.And(x => x.category.EndsWith(item.value));
                                break;
                            case "empty":
                                conditions = conditions.And(x => string.IsNullOrEmpty(x.category));
                                break;
                        }
                        break;

                    case "work_day":
                        // Try to parse item.value into a DayOfWeek enum
                        if (Enum.TryParse<DayOfWeek>(item.value, out var dayValue))
                        {
                            switch (item.operation)
                            {
                                case "=":
                                    conditions = conditions.And(x => x.work_day.Contains(dayValue));
                                    break;
                                case "!=":
                                    conditions = conditions.And(x => !x.work_day.Contains(dayValue));
                                    break;
                                case "contain":
                                    conditions = conditions.And(x => x.work_day.Contains(dayValue));
                                    break;
                                case "empty":
                                    conditions = conditions.And(x => !x.work_day.Any());
                                    break;
                            }
                        }
                        break;

                    case "reg_start_date":
                        if(DateTime.TryParse(item.value, out var dateVal))
                        {
                            switch (item.operation)
                            {
                                case "=":
                                    conditions = conditions.And(x => x.reg_start_date == dateVal);
                                    break;
                                case "!=":
                                    conditions = conditions.And(x => x.reg_start_date != dateVal);
                                    break;
                                case "<":
                                    conditions = conditions.And(x => x.reg_start_date < dateVal);
                                    break;
                                case "<=":
                                    conditions = conditions.And(x => x.reg_start_date <= dateVal);
                                    break;
                                case ">":
                                    conditions = conditions.And(x => x.reg_start_date > dateVal);
                                    break;
                                case ">=":
                                    conditions = conditions.And(x => x.reg_start_date >= dateVal);
                                    break;
                            }
                        }
                        
                        break;
                    case "reg_end_date":
                        if (DateTime.TryParse(item.value, out var dateendVal))
                        {
                            switch (item.operation)
                            {
                                case "=":
                                    conditions = conditions.And(x => x.reg_start_date == dateendVal);
                                    break;
                                case "!=":
                                    conditions = conditions.And(x => x.reg_start_date != dateendVal);
                                    break;
                                case "<":
                                    conditions = conditions.And(x => x.reg_start_date < dateendVal);
                                    break;
                                case "<=":
                                    conditions = conditions.And(x => x.reg_start_date <= dateendVal);
                                    break;
                                case ">":
                                    conditions = conditions.And(x => x.reg_start_date > dateendVal);
                                    break;
                                case ">=":
                                    conditions = conditions.And(x => x.reg_start_date >= dateendVal);
                                    break;
                            }
                        }

                        break;
                }
            }

            return conditions;
        }

        public Course_Dto GetCourseById(Guid id)
        {
            var result = _unitofwork.CourseRepo.GetById(id);
            var mappRes = _mapper.Map<Course_Dto>(result);

            return mappRes;
        }

        public bool IsExistById(Guid id)
        {
            var result = _unitofwork.CourseRepo.IsExistById(id).GetAwaiter().GetResult();
            return result;
        }

        public async Task<bool> IsExistByNameAsync(string name, Guid? id = null)
        {
            name = name.ToLower().Trim();
            var result =await _unitofwork.CourseRepo.GetlistAsync(x => x.title.Trim().ToLower() == name && (!id.HasValue || id != x.id), pageSize: -1);

            return result.Count > 0;
        }

        public bool IsHasCourseRegirestion(Guid id)
        {
            return _unitofwork.CourseRepo.IsHasCourseRegirestion(id);
        }

        public async Task<bool> IsHasCourseConfolictAsync(Course_Dto newCourse)
        {
            var result =await _unitofwork.CourseRepo.GetlistAsync(x => x.Trainer_id== newCourse.idTrainner, pageSize: -1);
            var conflict=IsConflict(newCourse,result);
            
            return conflict;
        }

        bool IsConflict(Course_Dto newCourse, List<Course> existingCourses)
        {
            foreach (var course in existingCourses)
            {
                // Only check if both courses share days of the week
                if (HasCommonDays(newCourse.work_day, course.work_day))
                {
                    // And they overlap in date ranges (same duration is fine, overlap just matters if time and day match)
                    if (DateRangesOverlap(newCourse.start_date, newCourse.end_date, course.start_date, course.end_date))
                    {
                        // Then check time overlap (this is the key rule)
                        if (TimeRangesOverlap(newCourse.start_time, newCourse.end_time, course.start_time, course.end_time))
                        {
                            return true; // Conflict found
                        }
                    }
                }
            }
            return false; // No conflict
        }

        private bool HasCommonDays(List<DayOfWeek> days1, List<DayOfWeek> days2)
        {
            return days1.Intersect(days2).Any();
        }
        private bool TimeRangesOverlap(TimeSpan start1, TimeSpan end1, TimeSpan start2, TimeSpan end2)
        {
            return start1 < end2 && start2 < end1;
        }
        private bool DateRangesOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            return start1 <= end2 && start2 <= end1;
        }


        public bool AddCourse(Course_Dto newCourse)
        {
            var mapModel = _mapper.Map<Course_Dto, Course>(newCourse);

            var result = _unitofwork.CourseRepo.Add(mapModel);
            _unitofwork.Save();

            return result;
        }

        public bool UpdateCourse(Guid id, Course_Dto updatedActivity)
        {
            var model = _unitofwork.CourseRepo.GetById(id);
            _mapper.Map<Course_Dto, Course>(updatedActivity, model);

            var result = _unitofwork.CourseRepo.update(model);
            _unitofwork.Save();

            return result;
        }

        public bool DeleteCourse(Guid id)
        {
            var model = _unitofwork.CourseRepo.GetById(id);

            var result = _unitofwork.CourseRepo.Delete(model);
            _unitofwork.Save();

            return result;
        }
    }
}
