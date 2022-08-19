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
using Authentication.Application.Features.CompanyFeatures.GetCompany;

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
        public async Task<IActionResult> GetCompany(string offset, string limit, string filter)
        {
            var result = await _mediator.Send(new GetAllCompanyRequestModel() { Offset=offset, Limit=limit, Filter=filter});
            return Ok(result);
        }

        [HttpGet("GetCompany/{companyCode}")]
        public async Task<IActionResult> GetCompany(string companyCode)
        {
            var result = await _mediator.Send(new GetCompanyRequestModel() { CompanyCode=companyCode});
            return Ok(result);
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
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(new { errorMessage = "Company Not Found" });
        }

        [HttpDelete("DeleteCompany/{companyCode}")]
        public async Task<IActionResult> DeleteCompany(string companyCode)
        {
            var result = await _mediator.Send(new DeleteCompanyRequestModel { CompanyCode = companyCode });
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(new { message = "Company Not Found" });
        }
    }
}
