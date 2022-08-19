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
            AddUserResponseModel response = new AddUserResponseModel();

            var user = UserMapper.Mapper.Map<AppUser>(request);
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                if (request.Role == "Admin")
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "Admin");
                    if(!roleResult.Succeeded)
                    {
                        return null;
                    }
                }

                var newUser = await _userManager.FindByNameAsync(request.UserName);
                response = UserMapper.Mapper.Map<AddUserResponseModel>(newUser);

                return response;
            }

            response.Errors = (List<IdentityError>)result.Errors;
            return response;

        }
    }
}
