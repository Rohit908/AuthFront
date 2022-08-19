using Authentication.Application.Features.CompanyFeatures.GetAllCompany;
using Authentication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.UserFeatures.GetAllUser
{
    public class GetAllUserResponseModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Company Company { get; set; }
    }
}
