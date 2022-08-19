using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.CompanyFeatures.GetCompany
{
    public class GetCompanyRequestModel:IRequest<GetCompanyResponseModel>
    {
        public string CompanyCode { get; set; }
    }
}
