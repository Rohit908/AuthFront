using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using core =  Authentication.Core.Entities;

namespace Authentication.Models
{
    public class TokenModel
    {
        public core.AppUser User { get; set; }
        public string Token { get; set; }
        public IList<string> Roles { get; set; }
    }
}
