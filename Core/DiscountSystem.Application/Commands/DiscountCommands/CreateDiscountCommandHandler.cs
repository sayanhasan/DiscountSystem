using DiscountSystem.Application.Extensions;
using DiscountSystem.Application.Repositories.UnitOfWork;
using DiscountSystem.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DiscountSystem.Application.Commands.DiscountCommands
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommandRequest, ServiceResponse<Discount>>
    {
        private readonly IUnitOfWork Worker;

        public CreateDiscountCommandHandler(IUnitOfWork worker)
        {
            Worker = worker;
        }

        public async Task<ServiceResponse<Discount>> Handle(CreateDiscountCommandRequest request, CancellationToken cancellationToken)
        {
            ServiceResponse<Discount> response = new();
            try
            {
                if (request.Rate < 0)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = "Discount Rate must be greater than 0.";
                    return response;
                }
                if (string.IsNullOrEmpty(request.Name))
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = "Discount Name could not be empty.";
                    return response;
                }
                var model = Worker.DiscountWriteRepo.Add(new Discount()
                {
                    Name = request.Name,
                    StartDate = Convert.ToDateTime(request.DiscountStartDate).DateToString(),
                    EndDate = Convert.ToDateTime(request.DiscountEndDate).DateToString(),
                });
                await Worker.CommitAsync();
                response.Message = "Created.";
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
