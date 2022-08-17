using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.CompanyFeatures.UpdateCompany
{
    public class UpdateCompanyRequestModel:IRequest<UpdateCompanyResponseModel>
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
    }
}
