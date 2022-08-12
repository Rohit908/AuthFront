using Authentication.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Queries.User
{
    public class GetUserByIdQuery:IRequest<UserResponse>
    {
        public string Id { get; set; }
    }
}
