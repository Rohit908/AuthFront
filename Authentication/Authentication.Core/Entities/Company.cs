using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Authentication.Core.Entities
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
