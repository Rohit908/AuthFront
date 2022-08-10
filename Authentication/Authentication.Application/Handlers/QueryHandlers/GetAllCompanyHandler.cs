using Authentication.Application.Queries;
using Authentication.Core.Entities;
using Authentication.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Handlers.QueryHandlers
{
    public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyQuery, List<Company>>
    {
        private readonly ICompanyRepository _companyRepo;
        public GetAllCompanyHandler(ICompanyRepository companyRepository)
        {
            _companyRepo = companyRepository;
        }
        public async Task<List<Company>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            return (List<Company>)await _companyRepo.GetAllAsync();
        }
    }
}
