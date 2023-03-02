using DiscountSystem.Application.Repositories.UnitOfWork;
using DiscountSystem.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Application.Queries.DiscountQueries
{
    public class GetAllDiscountQueryHandler : IRequestHandler<GetAllDiscountQueryRequest, ServiceResponse<List<Discount>>>
    {
        private readonly IUnitOfWork Worker;

        public GetAllDiscountQueryHandler(IUnitOfWork worker)
        {
            Worker = worker;
        }
        public async Task<ServiceResponse<List<Discount>>> Handle(GetAllDiscountQueryRequest request, CancellationToken cancellationToken)
        {
            ServiceResponse<List<Discount>> response = new();
            try
            {
                response.Data = Worker.DiscountReadRepo.GetList(tracking: false).ToList();
                response.Message = "List created.";
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
