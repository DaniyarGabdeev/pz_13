using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_13
{
    internal class Connector : DbContext
    {
        public DbSet<LaptopItem> Laptop => Set<LaptopItem>();
        public DbSet<ProductItem> Product => Set<ProductItem>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer((new SqlConnectionStringBuilder() { DataSource = "192.168.147.50\\MSSQL2", InitialCatalog = "again", UserID = "pk", Password = "1", TrustServerCertificate = true }).ConnectionString);

        }
    }
}
