using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public async Task<Toy> GetToy(int toyId)
        {
            var res = await _context.Toys.FirstOrDefaultAsync(t => t.Id == toyId);
            return res;
        }
        public async Task<List<Toy>> GetAllToys()
        {
            var list = await _context.Toys.Include("Company").Include("Sales").ToListAsync();            
            return list;
        }        

        public async Task<Toy> AddToy(Toy toy)
        {
            _context.Toys.Add(toy);

            await _context.SaveChangesAsync();
            return toy;
        }
        public async Task<Toy> AddToy(Toy toy, int companyId)
        {            
            _context.Companys.Include("Toys").FirstOrDefault(c=>c.Id == companyId).Toys.Add(toy);
            await _context.SaveChangesAsync();
            return toy;
        }
        public async Task<bool> AdditionAmountToy(Toy toy, int amount)
        {
            var selectedToy =  await _context.Toys.FirstOrDefaultAsync(t => t.Id == toy.Id);
            if (selectedToy == null) return false;
            selectedToy.Amount += amount;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> SubtractionAmountToy(int toyId, int amount)
        {
            var selectedToy = _context.Toys.FirstOrDefault(t => t.Id == toyId);
            if (selectedToy == null) return false;
            selectedToy.Amount -= amount;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
