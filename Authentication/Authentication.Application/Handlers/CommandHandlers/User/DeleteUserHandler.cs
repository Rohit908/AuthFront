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
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, UserResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        public DeleteUserHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = UserMapper.Mapper.Map<AppUser>(request);
            if (user is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var deletedUser = await _userManager.DeleteAsync(user);
            var userResponse = UserMapper.Mapper.Map<UserResponse>(deletedUser);
            return userResponse;
        }
    }
}
