using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyStore.Model
{
    public class Toy
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public double Weight { get; set; }
        public decimal Price { get; set; }
        public DateTime DateRelease { get; set; }
        public int Amount { get; set; }
        public Company Company { get; set; }
        public string AgeOfChildren { get; set; }
        public ICollection<SalesJournal> SalesJournals { get; set;}
    }
}
