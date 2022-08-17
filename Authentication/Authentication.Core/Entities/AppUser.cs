using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Authentication.Core.Entities
{
    public class AppUser:IdentityUser
    {
        public string CompanyCode { get; set; }
        [ForeignKey("CompanyCode")]
        public virtual Company Company { get; set; }
    }
}
