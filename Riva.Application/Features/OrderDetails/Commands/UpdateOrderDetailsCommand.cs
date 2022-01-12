using AutoMapper;
using MediatR;
using Riva.Application.DTOs.OrderDetails;
using Riva.Application.Interfaces;
using Riva.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Riva.Application.Features.OrderDetails.Commands
{
    public class UpdateOrderDetailsCommand : IRequest<Response<bool>>
    {
        public UpdateOrderDetailsDto OrderDetails { get; private set; }
        public UpdateOrderDetailsCommand(UpdateOrderDetailsDto orderDetails)
        {
            OrderDetails = orderDetails;
        }
    }

    public class UpdateOrderDetailsCommandHandler : IRequestHandler<UpdateOrderDetailsCommand, Response<bool>>
    {
        private readonly IRepository<Domain.Entities.OrdersDetails> _orderDetailsRepo;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public UpdateOrderDetailsCommandHandler(
            IRepository<Domain.Entities.OrdersDetails> orderDetailsRepo,
            IMapper mapper,
            IMediator mediator
            )
        {
            _orderDetailsRepo = orderDetailsRepo ?? throw new ArgumentNullException(nameof(orderDetailsRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<Response<bool>> Handle(UpdateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var orderDetailsToUpdate = await _orderDetailsRepo.GetByIdAsync(request.OrderDetails.OrdersDetailsID);
            orderDetailsToUpdate.QtyOrdered = request.OrderDetails.QtyOrdered;
            orderDetailsToUpdate.QtyInvoiced = request.OrderDetails.QtyInvoiced;
            orderDetailsToUpdate.QtyShipped = request.OrderDetails.QtyShipped;
            orderDetailsToUpdate.EntryDate = request.OrderDetails.EntryDate;
            orderDetailsToUpdate.DueDate = request.OrderDetails.DueDate;
            orderDetailsToUpdate.CustAdrsID = request.OrderDetails.CustAdrsID;
            orderDetailsToUpdate.Comment = request.OrderDetails.Comment;

            await _orderDetailsRepo.UpdateAsync(orderDetailsToUpdate);

            return new Response<bool>(true);
        }
    }
}
