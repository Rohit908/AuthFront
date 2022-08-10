using Authentication.Core.Entities;
using Authentication.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core.Repositories
{
    public interface ICompanyRepository: IRepository<Company>
    {
        Task<Company> GetByCodeAsync(string companyCode);
    }
}
