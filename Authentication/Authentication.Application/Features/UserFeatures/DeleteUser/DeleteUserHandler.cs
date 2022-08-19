using Authentication.Application.Mappers.User;
using Authentication.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Features.UserFeatures.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequestModel, DeleteUserResponseModel>
    {
        private readonly UserManager<AppUser> _userManager;
        public DeleteUserHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<DeleteUserResponseModel> Handle(DeleteUserRequestModel request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
                var response = UserMapper.Mapper.Map<DeleteUserResponseModel>(user);
                return response;
            }
            return null;
        }
    }
}
