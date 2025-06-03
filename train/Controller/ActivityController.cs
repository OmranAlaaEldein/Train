using System;
using System.Collections.Generic;
using Core_engtraining.IAppServices;
using CoreTrain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace train.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivityService _activityService;
        public ActivityController(IActivityService activityService) {
            _activityService= activityService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var myList = _activityService.GetAllActivities();
            return Ok(myList);
        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var model = _activityService.GetActivityById(id);
            return Ok(model);
        }

        [HttpPut()]
        public IActionResult UpdateProduct(Guid id, Activity_Dto upModel)
        {
            var isExist = _activityService.IsExistById(id);
            if (!isExist)
                return NotFound();

            var result = _activityService.UpdateActivity(id, upModel);
            return Ok(result);
        }

        [HttpDelete()]
        public IActionResult DeleteProduct(Guid id)
        {
            var isExist = _activityService.IsExistById(id);
            if (!isExist)
                return NotFound();

            var result = _activityService.DeleteActivity(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddActivivty(Activity_Dto newModel)
        {
            var result = _activityService.AddActivity(newModel);
            return Ok(result);
        }
    }
}
