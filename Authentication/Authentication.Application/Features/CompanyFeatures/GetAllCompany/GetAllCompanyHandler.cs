using Authentication.Core.Entities;
using Authentication.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Features.CompanyFeatures.GetAllCompany
{
    public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyRequestModel, List<Company>>
    {
        private readonly ICompanyRepository _companyRepo;
        public GetAllCompanyHandler(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }
        public async Task<List<Company>> Handle(GetAllCompanyRequestModel request, CancellationToken cancellationToken)
        {
            return (List<Company>) await _companyRepo.GetAllAsync();
        }
    }
}
