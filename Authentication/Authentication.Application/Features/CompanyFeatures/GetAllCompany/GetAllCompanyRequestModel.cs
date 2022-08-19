using Authentication.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.CompanyFeatures.GetAllCompany
{
    public class GetAllCompanyRequestModel: IRequest<GetAllCompanyResponseModel>
    {
        public string Offset { get; set; }
        public string Limit { get; set; }
        public string Filter { get; set; }
    }
}
