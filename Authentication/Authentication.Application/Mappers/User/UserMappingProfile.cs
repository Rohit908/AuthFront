using Authentication.Application.Commands.User;
using Authentication.Application.Features.UserFeatures.AddUser;
using Authentication.Application.Features.UserFeatures.DeleteUser;
using Authentication.Application.Features.UserFeatures.GetAllUser;
using Authentication.Application.Features.UserFeatures.UpdateUser;
using Authentication.Application.Queries;
using Authentication.Application.Responses;
using Authentication.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Mappers.User
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AppUser, AddUserResponseModel>().ReverseMap();
            CreateMap<AppUser, AddUserRequestModel>().ReverseMap();

            CreateMap<AppUser, GetAllUserResponseModel>().ReverseMap();
            CreateMap<AppUser, GetAllUserRequestModel>().ReverseMap();

            CreateMap<AppUser, UpdateUserResponseModel>().ReverseMap();
            CreateMap<AppUser, UpdateUserRequestModel>().ReverseMap();

            CreateMap<AppUser, DeleteUserResponseModel>().ReverseMap();

        }
    }
}
