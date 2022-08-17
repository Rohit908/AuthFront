using Authentication.Application.Mappers.User;
using Authentication.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Features.UserFeatures.AddUser
{
    public class AddUserHandler : IRequestHandler<AddUserRequestModel, AddUserResponseModel>
    {
        private readonly UserManager<AppUser> _userManager;
        public AddUserHandler(
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AddUserResponseModel> Handle(AddUserRequestModel request, CancellationToken cancellationToken)
        {
            var user = UserMapper.Mapper.Map<AppUser>(request);
            var result = await _userManager.CreateAsync(user, request.Password);

            if(result.Succeeded)
            {
                var newUser = await _userManager.FindByNameAsync(request.UserName);
                var response = UserMapper.Mapper.Map<AddUserResponseModel>(newUser);
                return response;
            }

            return null;

        }
    }
}
