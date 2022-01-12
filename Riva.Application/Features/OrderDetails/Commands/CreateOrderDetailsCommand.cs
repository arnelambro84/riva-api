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
    public class CreateOrderDetailsCommand : IRequest<Response<int>>
    {
        public CreateOrderDetailsDto OrderDetails { get; private set; }
        public CreateOrderDetailsCommand(CreateOrderDetailsDto orderDetails)
        {
            OrderDetails = orderDetails;
        }
    }

    public class CreateOrderDetailsCommandHandler : IRequestHandler<CreateOrderDetailsCommand, Response<int>>
    {
        private readonly IRepository<Domain.Entities.OrdersDetails> _orderDetailsRepo;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CreateOrderDetailsCommandHandler(
            IRepository<Domain.Entities.OrdersDetails> orderDetailsRepo,
            IMapper mapper,
            IMediator mediator
            )
        {
            _orderDetailsRepo = orderDetailsRepo ?? throw new ArgumentNullException(nameof(orderDetailsRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<Response<int>> Handle(CreateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var newOrderDetails = _mapper.Map<Domain.Entities.OrdersDetails>(request.OrderDetails);

            await _orderDetailsRepo.AddAsync(newOrderDetails);

            return new Response<int>(newOrderDetails.OrdersDetailsID);
        }
    }
}
