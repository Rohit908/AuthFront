using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.CompanyFeatures.UpdateCompany
{
    public class UpdateCompanyValidator:AbstractValidator<UpdateCompanyRequestModel>
    {
        public UpdateCompanyValidator()
        {
            RuleFor(v => v.CompanyCode).NotEmpty().NotNull();
            RuleFor(v => v.CompanyName).NotEmpty().NotNull().MinimumLength(3);
        }
    }
}
