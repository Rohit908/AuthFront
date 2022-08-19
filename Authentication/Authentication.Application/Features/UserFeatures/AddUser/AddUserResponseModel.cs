
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.UserFeatures.AddUser
{
    public class AddUserResponseModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<IdentityError> Errors { get; set; }

    }
}
