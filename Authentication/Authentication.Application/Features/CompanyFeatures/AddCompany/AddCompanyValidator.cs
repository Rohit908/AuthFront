using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.CompanyFeatures.AddCompany
{
    public class AddCompanyValidator:AbstractValidator<AddCompanyRequestModel>
    {
        public AddCompanyValidator()
        {
            RuleFor(v => v.CompanyName).NotEmpty().NotNull().MinimumLength(3);
        }
    }
}
