using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options ):base (options)
        {
            
        }


        public DbSet<Product> Prodcuts { get; set; }
        public DbSet<ProductBrand> ProdcutBrands { get; set; }
        public DbSet<ProductType> productTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemplyReferance).Assembly);

        }

    }
}
