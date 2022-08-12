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
            return await _mediator.Send(new GetAllCompanyQuery());
        }

        [HttpPost("AddCompany")]
        //[Authorize(Roles = "Owner")]
        public async Task<ActionResult<CompanyResponse>> CreateCompany(CreateCompanyCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteCompany/{companyCode}")]
        public async Task<IActionResult> DeleteCompany(string companyCode)
        {
            var result = await _mediator.Send(new DeleteCompanyCommand { CompanyCode = companyCode });
            return Ok(result);
        }
    }
}
