using Authentication.Application.Responses;
using Authentication.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Commands
{
    public class CreateCompanyCommand : IRequest<CompanyResponse>
    {
        public string CompanyName{ get; set; }
    }
}
