using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyStore.Model
{
    public class AgeOfChildren
    {
        public int Id { get; set; }
        public string Age { get; set; }
        public ICollection<Toy> Toys { get; set; }
    }
}
