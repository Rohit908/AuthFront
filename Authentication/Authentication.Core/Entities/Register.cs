using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Core.Entities
{
    public class Register
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyCode { get; set; }
        public bool asAdmin { get; set; } 
    }
}
