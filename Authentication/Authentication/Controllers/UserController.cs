using Authentication.Application.Commands.User;
using Authentication.Application.Features.UserFeatures.AddUser;
using Authentication.Application.Features.UserFeatures.DeleteUser;
using Authentication.Application.Features.UserFeatures.GetAllUser;
using Authentication.Application.Features.UserFeatures.UpdateUser;
using Authentication.Application.Queries;
using Authentication.Application.Queries.User;
using Authentication.Core.Entities;
using Authentication.Infrastructure.Data;
using Authentication.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetAllUser(string companyCode, string role)
        {
            var query = new GetAllUserRequestModel() { CompanyCode=companyCode, Role=role};
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var query = new GetUserByIdQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("AddUser")]
        //[Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddUser(AddUserRequestModel model, string role)
        {
            model.Role = role;
            var result = await _mediator.Send(model);

            if(result.Errors!=null)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        //[Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateUser(UpdateUserRequestModel command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteUser/{id}")]
        //[Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _mediator.Send(new DeleteUserRequestModel() { Id=id});
            return Ok(result);
        }

    }
}