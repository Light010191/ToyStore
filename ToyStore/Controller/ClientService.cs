using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Model;

namespace ToyStore.Controller
{
    public class ClientService : IService
    {
        public readonly AppDbContext _context;
        public ClientService()
        {
            _context = new AppDbContext();
        }
        public static  ClientService Instanse { get=>ClientServiceCreate.instance; }
        private class ClientServiceCreate
        {
            static ClientServiceCreate() { }
            internal static readonly ClientService instance= new ClientService();
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
