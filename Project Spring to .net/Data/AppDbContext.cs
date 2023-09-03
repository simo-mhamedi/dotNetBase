using Microsoft.EntityFrameworkCore;
using Project_Spring_to_.net.Models;
using System;

namespace Project_Spring_to_.net.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {

        }
        public DbSet<ClientCategory> clientCategories { get; set; }
        public DbSet<Client>  clients{ get; set; }
        public DbSet<Purchase> purchases{ get; set; }

    }
}
