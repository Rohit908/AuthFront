using Authentication.Application.Mappers;
using Authentication.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Application.Features.CompanyFeatures.DeleteCompany
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyRequestModel, DeleteCompanyResponseModel>
    {
        private readonly ICompanyRepository _companyRepo;
        public DeleteCompanyHandler(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }
        public async Task<DeleteCompanyResponseModel> Handle(DeleteCompanyRequestModel request, CancellationToken cancellationToken)
        {
            var companyEntitiy = await _companyRepo.GetByCodeAsync(request.CompanyCode);
            var deletedCompany = await _companyRepo.DeleteAsync(companyEntitiy);

            var companyResponse = CompanyMapper.Mapper.Map<DeleteCompanyResponseModel>(deletedCompany);
            return companyResponse;
        }
    }
}
