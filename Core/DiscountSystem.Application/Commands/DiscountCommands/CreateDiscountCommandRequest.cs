using DiscountSystem.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Application.Commands.DiscountCommands
{
    public class CreateDiscountCommandRequest : IRequest<ServiceResponse<Discount>>
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public DateTime DiscountStartDate { get; set; }
        public DateTime DiscountEndDate { get; set; }
    }
}
