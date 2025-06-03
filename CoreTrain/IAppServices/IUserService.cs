using System;
using System.Collections.Generic;
using System.Text;
using CoreTrain.Dto;
using DomainTrain.model;

namespace Core_engtraining.IAppServices
{
    public interface IUserService
    {
        public List<Course> GetAllCourses(int pageSize = 10, int pageNumber = 1, string orderBy = "title", string orderType = "asc");
        public Course GetCourseById(Guid id);
        public bool IsExistById(Guid id);
        public bool AddCourse(Course_Dto newCourse);
        public bool UpdateCourse(Guid id, Course_Dto updatedActivity);
        public bool DeleteCourse(Guid id);
    }
}
