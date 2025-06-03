using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace engineering_treaning.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Complaints_SuggestionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<string> myList = new List<string>();
            myList.Add("ff");
            return Ok(myList);
        }
        [HttpPut()]
        public IActionResult UpdateProduct()
        {
            List<string> myList = new List<string>();
            return Ok(myList);

        }
        [HttpDelete()]
        public IActionResult DeleteProduct()
        {
            List<string> myList = new List<string>();
            return Ok(myList);
        }
        [HttpPost]
        public IActionResult Post()
        {
            return BadRequest();
        }


    }
}
