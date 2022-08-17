using Authentication.Application.Mappers;
using Authentication.Core.Entities;
using Authentication.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Features.CompanyFeatures.UpdateCompany
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyRequestModel, UpdateCompanyResponseModel>
    {
        private readonly ICompanyRepository _companyRepo;
        public UpdateCompanyHandler(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        public async Task<UpdateCompanyResponseModel> Handle(UpdateCompanyRequestModel request, CancellationToken cancellationToken)
        {
            var company = CompanyMapper.Mapper.Map<Company>(request);
            if (company is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newCompany = await _companyRepo.UpdateAsync(company);
            var companyResponse = CompanyMapper.Mapper.Map<UpdateCompanyResponseModel>(newCompany);
            return companyResponse;
        }
    }
}
