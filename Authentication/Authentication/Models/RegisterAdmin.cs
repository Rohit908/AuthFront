﻿namespace Authentication.Models
{
    public class RegisterAdmin
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyCode { get; set; }
        public string Role { get; set; }
    }
}
