using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoreTrain.Dto;
using DomainTrain.model;


namespace Core_engtraining.IAppServices
{
  
  public interface ICourseService
    {

        public Task<List<Course_Dto>> GetAllCoursesAsync(List<Filter> filters, int pageSize = 10, int pageNumber = 1, string orderBy = "title", string orderType = "asc");
        public int GetAllCoursesCount(List<Filter> filters);
        
        public Course_Dto GetCourseById(Guid id);
        public bool IsExistById(Guid id);
        public Task<bool> IsExistByNameAsync(string name, Guid? id = null);
        public bool IsHasCourseRegirestion(Guid id);
        public Task<bool> IsHasCourseConfolictAsync(Course_Dto newCourse);

        public bool AddCourse(Course_Dto newCourse);
        public bool UpdateCourse(Guid id, Course_Dto updatedActivity);
        public bool DeleteCourse(Guid id);
    }
}
