using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ToyStore.Controller
{
    public interface IService
    {
        Task AddObject();
        Task GetObject();
        Task<bool> RemoveObject(int id);
    }
}
