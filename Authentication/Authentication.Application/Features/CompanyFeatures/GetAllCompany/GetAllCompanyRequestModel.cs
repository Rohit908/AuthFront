using Authentication.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.CompanyFeatures.GetAllCompany
{
    public class GetAllCompanyRequestModel: IRequest<List<Company>>
    {

    }
}
