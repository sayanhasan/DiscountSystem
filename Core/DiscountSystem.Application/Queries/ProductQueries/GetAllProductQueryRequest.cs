using DiscountSystem.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Application.Queries.ProductQueries
{
    public class GetAllProductQueryRequest : IRequest<ServiceResponse<List<Product>>>
    {
    }
}
