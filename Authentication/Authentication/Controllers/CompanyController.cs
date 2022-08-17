using Authentication.Application.Queries;
//using Authentication.Data;
//using Authentication.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Core.Entities;
using Authentication.Infrastructure.Data;
using Authentication.Application.Responses;
using Authentication.Application.Commands;
using Microsoft.AspNetCore.Authorization;
using Authentication.Application.Commands.Company;
using Authentication.Application.Features.CompanyFeatures.AddCompany;
using Authentication.Application.Features.CompanyFeatures.DeleteCompany;
using Authentication.Application.Features.CompanyFeatures.UpdateCompany;
using Authentication.Application.Features.CompanyFeatures.GetAllCompany;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyController(AppDbContext context, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCompany")]
        public async Task<List<Company>> GetCompany()
        {
            return await _mediator.Send(new GetAllCompanyRequestModel());
        }

        [HttpPost("AddCompany")]
        //[Authorize(Roles = "Owner")]
        public async Task<ActionResult<AddCompanyResponseModel>> CreateCompany(AddCompanyRequestModel command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateCompany")]
        //[Authorize(Roles = "Owner")]
        public async Task<ActionResult<UpdateCompanyResponseModel>> UpdateCompany(UpdateCompanyRequestModel command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteCompany/{companyCode}")]
        public async Task<IActionResult> DeleteCompany(string companyCode)
        {
            var result = await _mediator.Send(new DeleteCompanyRequestModel { CompanyCode = companyCode });
            return Ok(result);
        }
    }
}
