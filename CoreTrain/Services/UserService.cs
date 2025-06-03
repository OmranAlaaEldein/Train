using System;
using System.Collections.Generic;
using System.Text;
using Core_engtraining.IAppServices;
using CoreTrain.Dto;
using DomainTrain.model;

namespace Core_engtraining.Services
{
    public class UserService: IUserService
    {
        public bool AddCourse(Course_Dto newCourse)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCourse(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAllCourses(int pageSize = 10, int pageNumber = 1, string orderBy = "title", string orderType = "asc")
        {
            throw new NotImplementedException();
        }

        public Course GetCourseById(Guid id)
        {
            throw new NotImplementedException();
        }

        public string GetUser(int id)
        {
            return "";
        }

        public bool IsExistById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCourse(Guid id, Course_Dto updatedActivity)
        {
            throw new NotImplementedException();
        }
    }
}
