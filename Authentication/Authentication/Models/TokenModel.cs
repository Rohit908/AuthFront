using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Authentication.Models
{
    public class TokenModel
    {
        public IdentityUser User { get; set; }
        public string Token { get; set; }
        public IList<string> Roles { get; set; }
    }
}
