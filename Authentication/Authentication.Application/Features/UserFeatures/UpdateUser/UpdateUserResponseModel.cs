using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.UserFeatures.UpdateUser
{
    public class UpdateUserResponseModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
