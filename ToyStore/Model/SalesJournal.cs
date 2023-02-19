using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyStore.Model
{
    public class SalesJournal
    {
        public int Id { get; set; }
        public int Toy_Fk { get; set; }
        public DateTime DateSale { get; set; }
        public int Amount { get; set; }
        public ICollection<Toy> Toys { get; set; }
    }
}
