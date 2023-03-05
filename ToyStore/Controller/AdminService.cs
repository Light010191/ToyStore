using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Model;

namespace ToyStore.Controller
{
    public class AdminService
    {
        public readonly AppDbContext _context;
        public AdminService()
        {
            _context = new AppDbContext();
        }
        public static AdminService Instanse { get => AdminServiceCreate.instance; }
        private class AdminServiceCreate
        {
            static AdminServiceCreate() { }
            internal static readonly AdminService instance = new AdminService();
        }        

        public async Task<bool> LogIn(string login, string password)
        {
            var res = await _context.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
            return res != null;
        }
    }
}
