using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Model;

namespace ToyStore.Controller
{
    public class ClientService
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
        public async Task<IUser> AddObject(IUser user)
        {
            Client newClient = (Client)user;
            _context.Clients.Add(newClient);
            await _context.SaveChangesAsync();
            return newClient;
        } 
       
        public async Task<bool> LogIn(string login,string password) 
        {
            var res =await _context.Clients.FirstOrDefaultAsync(c => c.Login == login && c.Password == password);
            return res!=null;
        }
        public Task<bool> RemoveObject(int id)
        {
            throw new NotImplementedException();
        }
    }
}
