using Authentication.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.UserFeatures.AddUser
{
    public class AddUserRequestModel : IRequest<AddUserResponseModel>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyCode { get; set; }
    }
}
