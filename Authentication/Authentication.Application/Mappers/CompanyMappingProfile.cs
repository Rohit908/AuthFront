using Authentication.Application.Responses;
using Authentication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Authentication.Application.Commands;
using Authentication.Application.Commands.Company;
using Authentication.Application.Features.CompanyFeatures.AddCompany;
using Authentication.Application.Features.CompanyFeatures.DeleteCompany;
using Authentication.Application.Features.CompanyFeatures.UpdateCompany;

namespace Authentication.Application.Mappers
{
    public class CompanyMappingProfile:Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<Company, AddCompanyResponseModel>().ReverseMap();
            CreateMap<Company, AddCompanyRequestModel>().ReverseMap();

            CreateMap<Company, DeleteCompanyResponseModel>().ReverseMap();

            CreateMap<Company, UpdateCompanyResponseModel>().ReverseMap();
            CreateMap<Company, UpdateCompanyRequestModel>().ReverseMap();
        }
    }
}
