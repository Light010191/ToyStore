using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Model;

namespace ToyStore.Controller
{
    public class CompanyService 
    {
        AppDbContext _context;
        public CompanyService()
        {
            _context = new AppDbContext();
        }
        public static CompanyService Instance { get=>CompanyServiceCreate.instance; }
        private class CompanyServiceCreate
        {
            static CompanyServiceCreate() { }
            internal static readonly CompanyService instance = new CompanyService();
        }

        public async Task<bool> AddObject(Company company)
        {            
            _context.Companys.Add(company);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateObject(Company company)
        {
            var selectedCompany = await _context.Companys.FirstOrDefaultAsync(c => c.Id == company.Id);
            if (selectedCompany == null) return false;
            selectedCompany.Name = company.Name;
            selectedCompany.Country = company.Country;
            selectedCompany.Email = company.Email;
            selectedCompany.Toys = company.Toys;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Company> GetCompany(int companyId)
        {
            var res = await _context.Companys.FirstOrDefaultAsync(c=> c.Id == companyId);            
            return res;
        }
        public async Task<List<Company>> GetAllCompanys()
        {            
            var list = _context.Companys.ToList();            
            return list;
        }

        public Task<bool> RemoveObject(int id)
        {
            throw new NotImplementedException();
        }              

       
    }
}
