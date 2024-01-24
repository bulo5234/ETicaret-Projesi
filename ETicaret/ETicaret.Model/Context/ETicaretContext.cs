using ETicaret.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Context
{
    public class ETicaretContext : DbContext
    {
        public ETicaretContext(DbContextOptions<ETicaretContext> dbContextOptions) : base(dbContextOptions)
        {
        

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LoginGiris> Admins { get; set; }
    }
}
