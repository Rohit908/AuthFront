using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.UserFeatures.DeleteUser
{
    public class DeleteUserValidator:AbstractValidator<DeleteUserRequestModel>
    {
        public DeleteUserValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull();
        }
    }
}
