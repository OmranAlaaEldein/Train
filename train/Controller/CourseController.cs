using DomainTrain.model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Core_engtraining.IAppServices;
using CoreTrain.Dto;
using System;
using DomainTrain.IRepository;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using train.Resources;
using System.Globalization;

namespace engineering_treaning.Controller
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;
        private readonly IStringLocalizer<Resource> _localizer;

        public CourseController(ICourseService courseService, IStringLocalizer<Resource> localizer)
        {
            _courseService = courseService;
            _localizer = localizer;
        }


        
        [HttpPost("Filter")]
        public async Task<IActionResult> GetListAsync(PaggingRequest request)//logic in Activ-Course
        {
            var myList = await _courseService.GetAllCoursesAsync(request.filters, request.pageSize, request.pageNumber,request.orderBy,request.orderType);
            var countItems = _courseService.GetAllCoursesCount(request.filters);

            var result = new PaggingResponse<Course_Dto>()
            {
                items = myList,
                total = countItems,
                pageNumber = request.pageNumber,
                pageSize=request.pageSize
            };

            return Ok(myList);
        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var model = _courseService.GetCourseById(id);
            return Ok(model);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateCourseAsync(Guid id, Course_Dto upModel)
        {
            var isExist = _courseService.IsExistById(id);
            if (!isExist)
                return NotFound();

            var isExistName = await _courseService.IsExistByNameAsync(upModel.title,upModel.id);
            if (isExistName)
                return BadRequest(_localizer["Nameexist"]);

            var conflict = await _courseService.IsHasCourseConfolictAsync(upModel);
            if (isExistName)
                return BadRequest("conflictExist");

            var result = _courseService.UpdateCourse(id, upModel);
            return Ok(result);

        }

        [HttpDelete()]
        public IActionResult DeleteCourse(Guid id)
        {
            var isExist = _courseService.IsExistById(id);
            if (!isExist)
                return NotFound();

            var ishasCourse = _courseService.IsHasCourseRegirestion(id);
            if (!ishasCourse)
                return BadRequest("has course regirestion");

            var result = _courseService.DeleteCourse(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourseAsync(Course_Dto newModel)
        {
            var isExist =await _courseService.IsExistByNameAsync(newModel.title, newModel.id);
            if (isExist)
                return BadRequest("name exist");

            var result = _courseService.AddCourse(newModel);
            return Ok(result);
        }
    }

}

