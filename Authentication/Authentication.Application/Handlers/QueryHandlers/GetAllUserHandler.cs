using Authentication.Application.Mappers.User;
using Authentication.Application.Queries;
using Authentication.Application.Responses;
using Authentication.Core.Entities;
using Authentication.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Handlers.QueryHandlers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, List<UserResponse>>
    {
        private readonly UserManager<AppUser> _userManager;
        public GetAllUserHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<List<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync();
            var usersResponse = UserMapper.Mapper.Map<List<UserResponse>>(users);
            return usersResponse;
        }
    }
}
