using Authentication.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Application.Queries
{
    public class GetAllCompanyQuery: IRequest<List<Company>>
    {

    }
}
