using MediatR;
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
    public class DeleteOrderCommand : IRequest<Response<bool>>
    {
        public int OrderId { get; private set; }
        public DeleteOrderCommand(int orderId)
        {
            OrderId = orderId;
        }
    }

    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Response<bool>>
    {
        private readonly IRepository<Domain.Entities.Orders> _ordersRepo;
        public DeleteOrderCommandHandler(
            IRepository<Domain.Entities.Orders> ordersRepo)
        {
            _ordersRepo = ordersRepo ?? throw new ArgumentNullException(nameof(ordersRepo));
        }
        public async Task<Response<bool>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _ordersRepo.GetByIdAsync(request.OrderId);

            //To Do: Apply business rules when order has order details data

            await _ordersRepo.DeleteAsync(orderToDelete);

            return new Response<bool>(true);
        }
    }
}
