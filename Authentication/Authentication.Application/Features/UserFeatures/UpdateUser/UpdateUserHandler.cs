﻿using Authentication.Application.Mappers.User;
using Authentication.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Features.UserFeatures.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequestModel, UpdateUserResponseModel>
    {
        private readonly UserManager<AppUser> _userManager;
        public UpdateUserHandler(
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<UpdateUserResponseModel> Handle(UpdateUserRequestModel request, CancellationToken cancellationToken)
        {
            var user = UserMapper.Mapper.Map<AppUser>(request);
            var updatedUser = await _userManager.UpdateAsync(user);
            var response = UserMapper.Mapper.Map<UpdateUserResponseModel>(updatedUser);
            return response;
        }
    }
}