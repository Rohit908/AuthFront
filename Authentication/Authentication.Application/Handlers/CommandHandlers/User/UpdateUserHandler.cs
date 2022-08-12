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
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        public UpdateUserHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = UserMapper.Mapper.Map<AppUser>(request);
            if (user is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var newUser = await _userManager.UpdateAsync(user);
            var userResponse = UserMapper.Mapper.Map<UserResponse>(newUser);
            return userResponse;
        }
    }
}
