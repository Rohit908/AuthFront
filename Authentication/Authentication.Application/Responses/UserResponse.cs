using Authentication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Responses
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CompanyCode{ get; set; }
        public Company Companies { get; set; }
    }
}
