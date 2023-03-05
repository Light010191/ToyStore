using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyStore.Model
{
    public class Sales 
    {
        public int Id { get; set; }        
        public DateTime DateSale { get; set; }
        public int Amount { get; set; }
        public string ToyName { get; set; }
                
        

        public override string ToString()
        {
            return $"{Id}: {DateSale} , {ToyName} - {Amount}";
        }
    }
}
