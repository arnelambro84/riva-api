using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Riva.Application.DTOs.Orders;
using Riva.Application.Interfaces;
using Riva.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Riva.Application.Features.Orders.Queries
{
    public class GetOrdersQuery : IRequest<Response<IEnumerable<GetOrdersDto>>>
    {

    }

    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, Response<IEnumerable<GetOrdersDto>>>
    {
        private readonly IRepository<Domain.Entities.Orders> _ordersRepo;
        private readonly IMapper _mapper;
        public GetOrdersQueryHandler(
            IRepository<Domain.Entities.Orders> ordersRepo,
            IMapper mapper)
        {
            _ordersRepo = ordersRepo ?? throw new ArgumentNullException(nameof(ordersRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Response<IEnumerable<GetOrdersDto>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _ordersRepo.GetAsQueryable()
                .OrderByDescending(o => o.EntryDate)
                .Select(s => _mapper.Map<GetOrdersDto>(s))
                .ToListAsync();

            return new Response<IEnumerable<GetOrdersDto>>(orders);
        }
    }
}
