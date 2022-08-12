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
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, CompanyResponse>
    {
        private readonly ICompanyRepository _companyRepo;
        public DeleteCompanyHandler(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }
        public async Task<CompanyResponse> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyEntitiy = await _companyRepo.GetByCodeAsync(request.CompanyCode);
            var deletedCompany = await _companyRepo.DeleteAsync(companyEntitiy);

            var companyResponse = CompanyMapper.Mapper.Map<CompanyResponse>(deletedCompany);
            return companyResponse;
        }
    }
}
