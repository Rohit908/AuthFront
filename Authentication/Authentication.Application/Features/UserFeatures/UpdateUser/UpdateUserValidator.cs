using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.UserFeatures.UpdateUser
{
    public class UpdateUserValidator:AbstractValidator<UpdateUserRequestModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(v => v.UserName).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(v => v.Email).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(v => v.CompanyCode).NotEmpty().NotNull();
        }
    }
}
