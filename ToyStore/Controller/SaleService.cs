using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Model;

namespace ToyStore.Controller
{
    public class SaleService 
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

        public async Task<Sales> AddSale(Sales newSale)
        {
            _context.Sales.Add(newSale);
            await _context.SaveChangesAsync();
            return newSale;
        }
        public async Task<List<Sales>> GetAllSales()
        {
            var list = _context.Sales.ToList();            
            return list;
        }

        public async Task<Sales> GetObject(int id)
        {
            var sale = await _context.Sales.FirstOrDefaultAsync(s=>s.Id== id);
            return sale;
        }

            
    }
}
