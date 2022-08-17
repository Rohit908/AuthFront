using Authentication.Application.Mappers.User;
using Authentication.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Features.UserFeatures.GetAllUser
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserRequestModel, List<GetAllUserResponseModel>>
    {
        private readonly UserManager<AppUser> _userManager;
        public GetAllUserHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<List<GetAllUserResponseModel>> Handle(GetAllUserRequestModel request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.Include(x => x.Company).ToListAsync();

            if (request.Role != null)
            {
                users = (List<AppUser>)await _userManager.GetUsersInRoleAsync(request.Role);
            }

            if (request.CompanyCode!=null)
            {
                users = users.Where(x => x.CompanyCode == request.CompanyCode).ToList();
            }

            var response = UserMapper.Mapper.Map<List<GetAllUserResponseModel>>(users);
            return response;
        }
    }
}