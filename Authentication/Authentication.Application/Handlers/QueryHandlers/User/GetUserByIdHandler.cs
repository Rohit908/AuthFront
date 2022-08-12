using Authentication.Application.Mappers.User;
using Authentication.Application.Queries.User;
using Authentication.Application.Responses;
using Authentication.Core.Entities;
using Authentication.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Handlers.QueryHandlers.User
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        public GetUserByIdHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            var userResponse = UserMapper.Mapper.Map<UserResponse>(user);
            return userResponse;
        }
    }
}
