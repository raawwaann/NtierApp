using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NtierApp.Data;
namespace NtierApp.Data
{
    public class NtierAppContext : DbContext
    {
        public NtierAppContext(DbContextOptions<NtierAppContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

    }
}
