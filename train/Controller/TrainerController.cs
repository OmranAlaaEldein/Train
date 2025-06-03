using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core_engtraining.IAppServices;
using Core_engtraining.Services;
using CoreTrain.Dto;
using DomainTrain.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace engineering_treaning.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private ITrainanerService _trainner;
        private IConfiguration Configuration { get; }

        public TrainerController(ITrainanerService trainner, IConfiguration configuration)
        {

            _trainner = trainner;
            Configuration = configuration;
        }

        [Authorize]
        [HttpPost("Filter")]
        public IActionResult GetListAsync(PaggingRequest request)//logic in Activ-Course
        {
            var myList = _trainner.GetAllTrainner(request.filters, request.pageSize, request.pageNumber, request.orderBy, request.orderType);
            var countItems = _trainner.GetAllTrainCount(request.filters);

            var result = new PaggingResponse<Trainer_Dto>()
            {
                items = myList,
                total = countItems,
                pageNumber = request.pageNumber,
                pageSize = request.pageSize
            };
            return Ok(myList);
        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var model = _trainner.GetTrainanerById(id);
            return Ok(model);
        }

        [HttpPut()]
        public IActionResult UpdateTrainaner(Guid id, Trainer_Dto upModel)
        {
            var isExist = _trainner.IsExistById(id);
            if (!isExist)
                return NotFound();

            var isExistName = _trainner.IsExistByName(upModel.name,upModel.Id);
            if (isExistName)
                return BadRequest("name exist");


            var result = _trainner.UpdateTrainaner(id, upModel);
            return Ok(result);
        }

        [HttpDelete()]
        public IActionResult Delete(Guid id)
        {
            var isExist = _trainner.IsExistById(id);
            if (!isExist)
                return NotFound();

            var ishasCourse = _trainner.IsHaseCourse(id);
            if (!ishasCourse)
                return BadRequest("has course");

            var result = _trainner.DeleteTrainaner(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Trainer_Dto newModel)
        {

            var isExist = _trainner.IsExistByName(newModel.name);
            if (isExist)
                return BadRequest("name exist");

            var trainner = _trainner.GetTrainerByUserName(newModel.Username);
            // Check if username is taken
            if (trainner!=null)
                return Conflict("User already exists");

            //newModel.password = PasswordHelper.Hash(request.Password);
            
            var result = _trainner.AddTrainaner(newModel);
            return Ok(result);
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var trainner = _trainner.GetTrainerByUserName(model.Username);
            // Fake user validation for example
            if (trainner!=null && model.Password== trainner.password )
            {
                var jwtSettings = Configuration.GetSection("JwtSettings");
                var secretKey = jwtSettings["SecretKey"];
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Token = tokenString });
            }

            return Unauthorized();
        }
    }
}
