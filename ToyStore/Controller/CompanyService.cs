using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Model;

namespace ToyStore.Controller
{
    public class CompanyService : IService
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

        public Task AddObject()
        {
            throw new NotImplementedException();
        }

        public Task GetObject()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveObject(int id)
        {
            throw new NotImplementedException();
        }
    }
}
