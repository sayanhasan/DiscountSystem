using DiscountSystem.Application.Repositories;
using DiscountSystem.Application.Repositories.UnitOfWork;
using DiscountSystem.Domain.Models;
using DiscountSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Persistence.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            if (!context.Database.CanConnect())
            {
                context.Database.Migrate();
            }
            _context = context;
        }

        public IReadRepository<Product> ProductReadRepo => new ReadRepository<Product>(_context);

        public IWriteRepository<Product> ProductWriteRepo => new WriteRepository<Product>(_context);

        public IReadRepository<Category> CategoryReadRepo => new ReadRepository<Category>(_context);

        public IWriteRepository<Category> CategoryWriteRepo => new WriteRepository<Category>(_context);

        public IReadRepository<Discount> DiscountReadRepo => new ReadRepository<Discount>(_context);

        public IWriteRepository<Discount> DiscountWriteRepo => new WriteRepository<Discount>(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
