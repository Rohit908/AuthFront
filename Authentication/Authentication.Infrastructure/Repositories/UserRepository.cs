using Authentication.Core.Entities;
using Authentication.Core.Repositories;
using Authentication.Infrastructure.Data;
using Authentication.Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserRepository(
            UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<AppUser> AddUserAsync(Register entity)
        {
            var user = new AppUser { UserName = entity.UserName, Email = entity.Email, CompanyCode = entity.CompanyCode };
            var result = await _userManager.CreateAsync(user, entity.Password);
            if (result.Succeeded)
            {
                if(entity.asAdmin)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "Admin");
                    if(roleResult.Succeeded)
                    {
                        return user;
                    }
                }
                return user;
            }
            return null;
        }

        public Task DeleteUserAsync(Register entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<AppUser>> GetAllUserAsync()
        {
            return await _userManager.Users.Include(x=>x.Companies).ToListAsync();
        }

        public Task<AppUser> GetUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> UpdateUserAsync(AppUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
