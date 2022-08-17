using Authentication.Application.Commands.Company;
using Authentication.Application.Mappers;
using Authentication.Application.Responses;
using entity = Authentication.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Core.Repositories;

namespace Authentication.Application.Handlers.CommandHandlers.Company
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, CompanyResponse>
    {
        private readonly ICompanyRepository _companyRepo;
        public UpdateCompanyHandler(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }
        public async Task<CompanyResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyEntitiy = CompanyMapper.Mapper.Map<entity.Company>(request);
            if (companyEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newCompany = await _companyRepo.UpdateAsync(companyEntitiy);
            var companyResponse = CompanyMapper.Mapper.Map<CompanyResponse>(newCompany);
            return companyResponse;
        }
    }
}
