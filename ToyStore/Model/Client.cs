using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyStore.Controller;

namespace ToyStore.Model
{
    public class Client :IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return $"{Name} {Email}";
        }
    }
}
