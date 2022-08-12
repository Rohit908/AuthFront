using Authentication.Application.Commands.User;
using Authentication.Application.Mappers.User;
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

namespace Authentication.Application.Handlers.CommandHandlers.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        public CreateUserHandler(
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = UserMapper.Mapper.Map<AppUser>(request);

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                if(request.isAdmin)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "Admin");
                    if(!roleResult.Succeeded)
                    {
                        return null;
                    }
                }
                var userResponse = UserMapper.Mapper.Map<UserResponse>(user);
                return userResponse;
            }
            return null;
        }
    }
}
