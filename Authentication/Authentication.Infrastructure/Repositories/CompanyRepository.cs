using Authentication.Core.Entities;
using Authentication.Core.Repositories;
using Authentication.Infrastructure.Data;
using Authentication.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Company>> GetCompanyWithFilter(string filter)
        {
            return await _context.Set<Company>().Where(c => c.CompanyName.Contains(filter)).ToListAsync();
        }



        //public new async Task<Company> AddAsync(Company entity)
        //{
        //    entity.IsActive = true;
        //    var company = _context.Set<Company>().FirstOrDefault(x=>x.CompanyName==entity.CompanyName);
        //    if (company == null)
        //    {
        //        await _context.AddAsync(entity);
        //        await _context.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        company.IsActive = true;
        //        _context.Set<Company>().Update(company);
        //        await _context.SaveChangesAsync();
        //    }
        //    return entity;
        //}

        //public new async Task<IReadOnlyList<Company>> GetAllAsync()
        //{
        //    return await _context.Set<Company>().Where(c=>c.IsActive).ToListAsync();
        //}
        //public new async Task<Company> DeleteAsync(Company entity)
        //{
        //    entity.IsActive = false;
        //    _context.Set<Company>().Update(entity);
        //    await _context.SaveChangesAsync();
        //    return entity;
        //}

    }
}
