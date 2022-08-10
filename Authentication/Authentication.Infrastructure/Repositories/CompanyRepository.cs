using Authentication.Core.Entities;
using Authentication.Core.Repositories;
using Authentication.Infrastructure.Data;
using Authentication.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<Company> GetByCodeAsync(string companyCode)
        {
            return await _context.Set<Company>().FindAsync(companyCode);
        }

    }
}
