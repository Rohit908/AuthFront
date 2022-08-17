using Authentication.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Commands.Company
{
    public class UpdateCompanyCommand: IRequest<CompanyResponse>
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
    }
}
