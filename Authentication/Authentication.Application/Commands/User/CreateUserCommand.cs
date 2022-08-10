using Authentication.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Commands.User
{
    public class CreateUserCommand: IRequest<UserResponse>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CompanyCode { get; set; }
        public bool asAdmin { get; set; } = false;
    }
}
