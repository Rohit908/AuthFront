using Authentication.Application.Commands;
using Authentication.Application.Mappers;
using Authentication.Application.Responses;
using Authentication.Core.Entities;
using Authentication.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Handlers.CommandHandlers
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CompanyResponse>
    {
        private readonly ICompanyRepository _companyRepo;
        public CreateCompanyHandler(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        public async Task<CompanyResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyEntitiy = CompanyMapper.Mapper.Map<Company>(request);
            if (companyEntitiy is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newCompany = await _companyRepo.AddAsync(companyEntitiy);
            var companyResponse = CompanyMapper.Mapper.Map<CompanyResponse>(newCompany);
            return companyResponse;
        }
    }
}
