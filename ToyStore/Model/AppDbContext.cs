using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ToyStore.Model
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<SalesJournal> SalesJournals { get; set;}
        public DbSet<AgeOfChildren> AgeOfChildren { get; set;}
        public DbSet<Company> Companys { get; set; }        
    }
}
