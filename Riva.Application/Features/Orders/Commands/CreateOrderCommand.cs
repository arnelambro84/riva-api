using AutoMapper;
using MediatR;
using Riva.Application.DTOs.Orders;
using Riva.Application.Features.Orders.Events.Notifications;
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
    public class CreateOrderCommand : IRequest<Response<int>>
    {
        public CreateOrderDto Order { get; private set; }
        public CreateOrderCommand(CreateOrderDto order)
        {
            Order = order;
        }
    }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<int>>
    {
        private readonly IRepository<Domain.Entities.Orders> _ordersRepo;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CreateOrderCommandHandler(
            IRepository<Domain.Entities.Orders> ordersRepo,
            IMapper mapper,
            IMediator mediator)
        {
            _ordersRepo = ordersRepo ?? throw new ArgumentNullException(nameof(ordersRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<Response<int>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newOrder = _mapper.Map<Domain.Entities.Orders>(request.Order);

            await _ordersRepo.AddAsync(newOrder);

            await _mediator.Publish(new OnOrdersCreated(newOrder.OrdersID));

            return new Response<int>(newOrder.OrdersID);
        }
    }
}
