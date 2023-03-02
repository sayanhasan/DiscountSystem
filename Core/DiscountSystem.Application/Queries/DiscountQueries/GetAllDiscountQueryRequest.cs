using DiscountSystem.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Application.Queries.DiscountQueries
{
    public class GetAllDiscountQueryRequest:IRequest<ServiceResponse<List<Discount>>>
    {

    }
}
