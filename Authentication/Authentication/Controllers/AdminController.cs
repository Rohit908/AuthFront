using Authentication.Core.Entities;
using Authentication.Infrastructure.Data;
using Authentication.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        public AdminController(
            UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }


        [HttpGet("GetUsers/{companyCode}")]
        //[Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetUsers(string companyCode)
        {
            var users = _userManager.Users.Where(x=>x.CompanyCode==companyCode).ToList();
            if(users!=null)
            {
                return Ok(users);
            }
            return BadRequest(new { message = "No users found" });
        }

        [HttpPost("AddAdmin")]
        [Authorize(Roles = "Owner", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddAdmin(RegisterAdmin register)
        {
            var user = new AppUser { UserName = register.UserName, Email = register.Email, CompanyCode = register.CompanyCode };
            var result = await _userManager.CreateAsync(user, register.Password);
            
            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "Admin");
                if (roleResult.Succeeded)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest(roleResult.Errors.Select(x => x.Description));
                }
            }
            return BadRequest(result.Errors.Select(x => x.Description));
        }


        [HttpPost("AddRole")]
        public async Task<IActionResult> CreateRole(Role model)
        {
            IdentityRole identityRole = new IdentityRole
            {
                Name = model.RoleName
            };
            var result = await _roleManager.CreateAsync(identityRole);
            if(result.Succeeded)
            {
                return Ok(new {message = "Role Created" });
            }

            return BadRequest(result.Errors.Select(x => x.Description));
        }


        [HttpPost("MapRole")]
        public async Task<IActionResult> MapRole(UserRoleResponse model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            
            List<string> rolesToAdd = new List<string>();
            List<string> rolesToRemove = new List<string>();

            foreach (var r in model.userRoles)
            {
                if(r.IsAssigned && !await _userManager.IsInRoleAsync(user, r.RoleName))
                {
                    rolesToAdd.Add(r.RoleName);
                }
                else if(!r.IsAssigned && await _userManager.IsInRoleAsync(user, r.RoleName))
                {
                    rolesToRemove.Add(r.RoleName);
                }
            }

            var result1 = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

            if (!result1.Succeeded)
            {
                return BadRequest(result1.Errors);
            }

            var result = await _userManager.AddToRolesAsync(user, rolesToAdd);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { message = "Role Mapped" });
        }


        [HttpGet("GetUsersAndRoles/{companyCode}")]
        public async Task<IActionResult> GetUsersAndRoles(string companyCode)
        {

            List<UserRoleResponse> model = new List<UserRoleResponse>();

            var users = _userManager.Users.Where(x=>x.CompanyCode==companyCode).ToList();
            var roles = _roleManager.Roles;

            foreach (var user in users)
            {
                List<UserRole> userRoleList = new List<UserRole>();
                foreach (var role in roles)
                {
                    UserRole userRole = new UserRole()
                    {
                        RoleName = role.Name
                    };

                    if(await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        userRole.IsAssigned = true;
                    }
                    else
                    {
                        userRole.IsAssigned = false;
                    }

                    userRoleList.Add(userRole);
                }

                var userRoleResponse = new UserRoleResponse() { UserName = user.UserName,userRoles = userRoleList };
                model.Add(userRoleResponse);
            }

            if(User!=null)
            {
                return Ok(model);
            }

            return BadRequest(new {message="User or role not found"});
        }

        [HttpGet("GetCompany")]
        public IActionResult GetCompany()
        {

            var companies = _context.Company.ToList();

            if(companies!=null)
            {
                return Ok(companies);
            }

            return BadRequest(new { message = "User or role not found" });
        }


    }
}
