using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class ETradeContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SQL Server Authentication
            string connectionString = @"Server=.\SQLEXPRESS;database=ETradeIA;user id=sa;password=sa;trustservercertificate=true;multipleactiveresultsets=true;";

            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
