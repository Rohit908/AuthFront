using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.UserFeatures.DeleteUser
{
    public class DeleteUserRequestModel:IRequest<DeleteUserResponseModel>
    {
        public string Id { get; set; }
    }
}
