using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.UserFeatures.GetAllUser
{
    public class GetAllUserRequestModel:IRequest<List<GetAllUserResponseModel>>
    {
        public string CompanyCode { get; set; }
        public string Role { get; set; }
    }
}
