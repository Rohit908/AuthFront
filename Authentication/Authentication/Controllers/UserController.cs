using Authentication.Application.Commands.User;
using Authentication.Application.Queries;
using Authentication.Core.Entities;
using Authentication.Infrastructure.Data;
using Authentication.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public UserController(
            UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            AppDbContext context,
            IMediator mediator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _mediator = mediator;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var query = new GetAllUserQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("AddUser")]
        //[Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddUser(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
