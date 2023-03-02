using DiscountSystem.Application.Repositories.UnitOfWork;
using DiscountSystem.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Application.Queries.ProductQueries
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, ServiceResponse<List<Product>>>
    {
        private readonly IUnitOfWork Worker;

        public GetAllProductQueryHandler(IUnitOfWork worker)
        {
            Worker = worker;
        }
        public async Task<ServiceResponse<List<Product>>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            ServiceResponse<List<Product>> response = new();
            try
            {
                response.Data = Worker.ProductReadRepo.GetList(tracking:false).ToList();
                foreach (var item in response.Data)
                {
                    var categories = Worker.CategoryReadRepo.GetListByFilter(filter: x => x.Id == item.Id, includes: new string[] { "Discount" });
                    if (categories == null)
                    {
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        response.Message = "Product category not found.";
                        return response;
                    }
                    item.Price -= item.Price / categories.FirstOrDefault().Discount.Rate;
                }
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
