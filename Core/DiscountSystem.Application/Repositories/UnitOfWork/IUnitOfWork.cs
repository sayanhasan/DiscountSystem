using DiscountSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Application.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IReadRepository<Product> ProductReadRepo { get; }
        IWriteRepository<Product> ProductWriteRepo { get; }
        IReadRepository<Discount> DiscountReadRepo { get; }
        IWriteRepository<Discount> DiscountWriteRepo { get; }
        IReadRepository<Category> CategoryReadRepo { get; }
        IWriteRepository<Category> CategoryWriteRepo { get; }
        Task<int> CommitAsync();
    }
}
