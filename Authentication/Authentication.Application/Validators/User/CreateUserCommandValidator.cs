using Authentication.Application.Commands.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Validators.User
{
    public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.UserName).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(v=>v.Email).NotEmpty().NotNull();
            RuleFor(v=>v.Password).NotEmpty().NotNull();
            RuleFor(v => v.CompanyCode).NotNull();
        }
    }
}
