using DiscountSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder optBuilder = new();
            optBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(optBuilder.Options);
        }
    }
}
