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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        
        [HttpPost("AddUser")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddUser([FromBody] Register register)
        {
            var user = new IdentityUser { UserName = register.UserName, Email = register.Email };
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                return Ok(user);
            }
            return BadRequest(result.Errors.Select(x=>x.Description));
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

            foreach(var r in model.userRoles)
            {
                if(r.IsAssigned && !await _userManager.IsInRoleAsync(user, r.RoleName))
                {
                    var result = await _userManager.AddToRoleAsync(user, r.RoleName);

                    if (result.Succeeded)
                    {
                        continue;
                    }
                    else
                    {
                        return BadRequest(result.Errors);
                    }
                }
                else
                {
                    var result = await _userManager.RemoveFromRoleAsync(user, r.RoleName);

                    if (result.Succeeded)
                    {
                        continue;
                    }
                    else
                    {
                        return BadRequest(result.Errors);
                    }
                }
            }

            return Ok(new { message = "Role Mapped" });
        }


        [HttpGet("GetUsersAndRoles")]
        public async Task<IActionResult> GetUsersAndRoles()
        {

            List<UserRoleResponse> model = new List<UserRoleResponse>();

            var users = _userManager.Users;
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

    }
}
