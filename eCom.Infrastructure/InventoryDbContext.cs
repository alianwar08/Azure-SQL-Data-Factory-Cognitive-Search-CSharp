using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eCom.Infrastructure.Persistance.Repositories;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace eCom.Infrastructure.Persistance
{
    public class InventoryDbContext : DbContext
    {

        public InventoryDbContext() : base()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConnectionString = @"data source = aa-dbsrv-ecom.database.windows.net; initial catalog = aa-adb-ecom; persist security info = True; user id = ecom; password = xuD2%dxuD2%d; multipleactiveresultsets = True;TrustServerCertificate=True; application name =$Application_Name$";
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrdersProducts>()
                .HasKey(a => new { a.order_id, a.product_id });
        }


    }

}
