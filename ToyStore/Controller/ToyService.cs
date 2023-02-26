using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Model;

namespace ToyStore.Controller
{
    public class ToyService
    {
        AppDbContext _context;
        public ToyService() 
        {
            _context = new AppDbContext();
        }
        public static ToyService Instance { get => ToyServiceCreate.instance; }
        private class ToyServiceCreate
        {
            static ToyServiceCreate() { }
            internal static readonly ToyService instance = new ToyService();
        }       

        public Task GetObject()
        {
            throw new NotImplementedException();
        }
        public async Task<List<Toy>> GetAllToys()
        {
            var list = _context.Toys.Include("Company").ToList();            
            return list;
        }
        public Task<bool> RemoveObject(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Toy> AddToy(Toy toy)
        {
            _context.Toys.Add(toy);
            await _context.SaveChangesAsync();
            return toy;
        }
        public async Task<Toy> AddToy(Toy toy, Company company)
        {
            _context.Toys.Include("Companys").FirstOrDefault(t=>t.Id == toy.Id).Company=company;
            await _context.SaveChangesAsync();
            return toy;
        }
        public async Task<bool> UpdateAmountToy(Toy toy, int amount)
        {
            var selectedToy =  await _context.Toys.FirstOrDefaultAsync(t => t.Id == toy.Id);
            if (selectedToy == null) return false;
            selectedToy.Amount += amount;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
