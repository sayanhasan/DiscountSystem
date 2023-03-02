using DiscountSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        int Add(T entity);
        bool Remove(T entity);
        bool RemoveById(int id);
        int Update(T entity);
    }
}
