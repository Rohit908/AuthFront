using Authentication.Core.Entities;
using Authentication.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core.Repositories
{
    public interface IUserRepository
    {
        Task<IReadOnlyList<AppUser>> GetAllUserAsync();
        Task<AppUser> GetUserByIdAsync(string id);
        Task<AppUser> AddUserAsync(Register entity);
        Task<AppUser> UpdateUserAsync(AppUser entity);
        Task DeleteUserAsync(AppUser entity);
    }
}
