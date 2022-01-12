using MediatR;
using Riva.Application.Interfaces;
using Riva.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Riva.Application.Features.OrderDetails.Commands
{
    public class DeleteOrderDetailsCommand : IRequest<Response<bool>>
    {
        public int OrderDetailsId { get; private set; }

        public DeleteOrderDetailsCommand(int orderDetailsId)
        {
            OrderDetailsId = orderDetailsId;
        }
    }

    public class DeleteOrderDetailsCommandHandler : IRequestHandler<DeleteOrderDetailsCommand, Response<bool>>
    {
        private readonly IRepository<Domain.Entities.OrdersDetails> _orderDetailsRepo;
        public DeleteOrderDetailsCommandHandler(
            IRepository<Domain.Entities.OrdersDetails> orderDetailsRepo
            )
        {
            _orderDetailsRepo = orderDetailsRepo ?? throw new ArgumentNullException(nameof(orderDetailsRepo));
        }
        public async Task<Response<bool>> Handle(DeleteOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var orderDetailsToDelete = await _orderDetailsRepo.GetByIdAsync(request.OrderDetailsId);

            await _orderDetailsRepo.DeleteAsync(orderDetailsToDelete);

            return new Response<bool>(true);
        }
    }
}
