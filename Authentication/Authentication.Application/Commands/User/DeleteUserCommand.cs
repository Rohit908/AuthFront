using Authentication.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Commands.User
{
    public class DeleteUserCommand:IRequest<UserResponse>
    {
        public string Id { get; set; }
    }
}
