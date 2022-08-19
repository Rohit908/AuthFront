using Authentication.Application.Mappers;
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
    public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyRequestModel, GetAllCompanyResponseModel>
    {
        private readonly ICompanyRepository _companyRepo;
        public GetAllCompanyHandler(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }
        public async Task<GetAllCompanyResponseModel> Handle(GetAllCompanyRequestModel request, CancellationToken cancellationToken)
        {
            List<Company> companies = new List<Company>();
            if (request.Offset!=null&&request.Limit!=null)
            {
                companies = await _companyRepo.GetCompanyWithOffsetLimit(request.Offset, request.Limit);
            }
            else if(request.Filter!=null)
            {
                companies = await _companyRepo.GetCompanyWithFilter(request.Filter);
            }
            else
            {
                companies = (List<Company>)await _companyRepo.GetAllAsync();
            }

            var response = new GetAllCompanyResponseModel();
            response.Companies = companies;
            response.Size = await _companyRepo.GetSize();
            return response;
        }
    }
}
