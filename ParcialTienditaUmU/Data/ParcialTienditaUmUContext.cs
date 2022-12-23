using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParcialTienditaUmU.Models;

namespace ParcialTienditaUmU.Data
{
    public class ParcialTienditaUmUContext : DbContext
    {
        public ParcialTienditaUmUContext (DbContextOptions<ParcialTienditaUmUContext> options)
            : base(options)
        {
        }

        public DbSet<ParcialTienditaUmU.Models.User> User { get; set; } = default!;

        public DbSet<ParcialTienditaUmU.Models.Products> Products { get; set; }

        public DbSet<ParcialTienditaUmU.Models.Orders> Orders { get; set; }

        public DbSet<ParcialTienditaUmU.Models.Sells> Sells { get; set; }
    }
}
