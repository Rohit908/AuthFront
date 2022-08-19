using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.UserFeatures.AddUser
{
    public class AddUserValidator:AbstractValidator<AddUserRequestModel>
    {
        public AddUserValidator()
        {
            RuleFor(v => v.UserName).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(v => v.Email).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(v => v.Password).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(v => v.CompanyCode).NotEmpty().NotNull();
        }
    }
}
