using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Model;

namespace ToyStore.Controller
{
    public class ToyService : IService
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
