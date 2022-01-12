using MediatR;
using Riva.Application.DTOs.Orders;
using Riva.Application.Interfaces;
using Riva.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Riva.Application.Features.Orders.Commands
{
    public class UpdateOrderCommand : IRequest<Response<bool>>
    {
        public UpdateOrderDto Order { get; private set; }
        public UpdateOrderCommand(UpdateOrderDto order)
        {
            Order = order;
        }
    }

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Response<bool>>
    {
        private readonly IRepository<Domain.Entities.Orders> _ordersRepo;
        public UpdateOrderCommandHandler(
            IRepository<Domain.Entities.Orders> ordersRepo)
        {
            _ordersRepo = ordersRepo ?? throw new ArgumentNullException(nameof(ordersRepo));
        }
        public async Task<Response<bool>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _ordersRepo.GetByIdAsync(request.Order.OrdersID);
            orderToUpdate.POInternal = request.Order.POInternal;
            orderToUpdate.POExternal = request.Order.POExternal;
            orderToUpdate.ReceivedDate = request.Order.ReceivedDate;
            orderToUpdate.EntryDate = request.Order.EntryDate;
            orderToUpdate.RequiredDate = request.Order.RequiredDate;
            orderToUpdate.TotalShippedDate = request.Order.TotalShippedDate;
            orderToUpdate.OrderStatusID = request.Order.OrderStatusID;
            orderToUpdate.Comment = request.Order.Comment;

            await _ordersRepo.UpdateAsync(orderToUpdate);

            return new Response<bool>(true);
        }
    }
}
