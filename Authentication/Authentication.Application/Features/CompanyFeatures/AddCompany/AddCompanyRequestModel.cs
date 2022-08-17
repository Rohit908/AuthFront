using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.CompanyFeatures.AddCompany
{
    public class AddCompanyRequestModel:IRequest<AddCompanyResponseModel>
    {
        public string CompanyName { get; set; }
    }
}
