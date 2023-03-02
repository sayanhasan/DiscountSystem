using DiscountSystem.Application.Repositories.UnitOfWork;
using DiscountSystem.Persistence.Contexts;
using DiscountSystem.Persistence.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString), ServiceLifetime.Transient);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
