using Authentication.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Commands
{
    public class DeleteCompanyCommand:IRequest<string>
    {
        public string CompanyCode { get; set; }
    }
}
