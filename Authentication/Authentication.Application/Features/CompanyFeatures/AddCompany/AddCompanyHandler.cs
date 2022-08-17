using Authentication.Application.Mappers;
using Authentication.Core.Entities;
using Authentication.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Features.CompanyFeatures.AddCompany
{
    public class AddCompanyHandler:IRequestHandler<AddCompanyRequestModel, AddCompanyResponseModel>
    {
        private readonly ICompanyRepository _companyRepo;
        public AddCompanyHandler(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        public async Task<AddCompanyResponseModel> Handle(AddCompanyRequestModel request, CancellationToken cancellationToken)
        {
            var companyEntitiy = CompanyMapper.Mapper.Map<Company>(request);
            if (companyEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }

            var newCompany = await _companyRepo.AddAsync(companyEntitiy);
            var companyResponse = CompanyMapper.Mapper.Map<AddCompanyResponseModel>(newCompany);
            return companyResponse;
        }
    }
}
