using Authentication.Application.Mappers;
using Authentication.Core.Entities;
using Authentication.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Features.CompanyFeatures.GetCompany
{
    public class GetCompanyHandler : IRequestHandler<GetCompanyRequestModel, GetCompanyResponseModel>
    {
        private readonly ICompanyRepository _companyRepo;
        public GetCompanyHandler(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }
        public async Task<GetCompanyResponseModel> Handle(GetCompanyRequestModel request, CancellationToken cancellationToken)
        {
            var company = await _companyRepo.GetByCodeAsync(request.CompanyCode); 
            var response = CompanyMapper.Mapper.Map<GetCompanyResponseModel>(company);
            return response;
        }
    }
}
