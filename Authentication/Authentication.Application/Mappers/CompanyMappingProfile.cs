using Authentication.Application.Responses;
using Authentication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Authentication.Application.Commands;

namespace Authentication.Application.Mappers
{
    public class CompanyMappingProfile:Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<Company, CompanyResponse>().ReverseMap();
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();
        }
    }
}
