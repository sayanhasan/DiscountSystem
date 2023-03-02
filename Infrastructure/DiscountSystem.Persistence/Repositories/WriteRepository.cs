using DiscountSystem.Application.Repositories;
using DiscountSystem.Domain.Models;
using DiscountSystem.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public WriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();


        public int Add(T entity)
        {
            var model = Table.Add(entity);
            return model.Entity.Id;
        }

        public bool Remove(T entity)
        {
            var model = Table.Remove(entity);
            return model.State == EntityState.Deleted;
        }

        public bool RemoveById(int id)
        {
            var model = Table.FirstOrDefault(x => x.Id == id);
            return Remove(model);
        }

        public int Update(T entity)
        {
            var model = Table.Update(entity);
            return model.Entity.Id;
        }
    }
}
