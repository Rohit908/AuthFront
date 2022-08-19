using Authentication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.CompanyFeatures.GetAllCompany
{
    public class GetAllCompanyResponseModel
    {
        public List<Company> Companies { get; set; }
        public int Size { get; set; }
    }
}
