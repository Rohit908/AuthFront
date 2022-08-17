using Authentication.Application.Responses;
using Authentication.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Queries
{
    public class GetAllUserQuery:IRequest<List<UserResponse>>
    {
        public string Role { get; set; }
    }
}
