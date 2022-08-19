using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Features.CompanyFeatures.DeleteCompany
{
    public class DeleteCompanyValidator:AbstractValidator<DeleteCompanyRequestModel>
    {
        public DeleteCompanyValidator()
        {
            RuleFor(v => v.CompanyCode).NotEmpty().NotNull();
        }
    }
}
