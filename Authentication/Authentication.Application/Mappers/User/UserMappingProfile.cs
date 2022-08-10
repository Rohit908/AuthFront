using Authentication.Application.Commands.User;
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
            CreateMap<AppUser, UserResponse>().ReverseMap();
            CreateMap<Register, CreateUserCommand>().ReverseMap();
        }
    }
}
