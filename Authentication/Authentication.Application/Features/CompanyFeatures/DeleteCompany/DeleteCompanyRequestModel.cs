using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.CompanyFeatures.DeleteCompany
{
    public class DeleteCompanyRequestModel:IRequest<DeleteCompanyResponseModel>
    {
        public string CompanyCode { get; set; }
    }
}
