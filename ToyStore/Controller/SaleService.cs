using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Model;

namespace ToyStore.Controller
{
    public class SaleService : IService
    {
        AppDbContext _context;
        public SaleService()
        {
            _context = new AppDbContext();
        }
        public static SaleService Instance { get=>SaleServiceCreate.instance; }
        private class SaleServiceCreate
        {
            static SaleServiceCreate() { }
            internal static readonly SaleService instance = new SaleService();
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
