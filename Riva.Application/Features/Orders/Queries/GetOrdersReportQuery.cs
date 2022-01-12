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
    public class GetOrdersReportQuery : IRequest<Response<IEnumerable<GetOrdersReportDto>>>
    {

    }

    public class GetOrdersReportQueryHandler : IRequestHandler<GetOrdersReportQuery, Response<IEnumerable<GetOrdersReportDto>>>
    {
        private readonly IRepository<Domain.Entities.OrdersDetails> _ordersDetailsRepo;
        private readonly IMapper _mapper;
        public GetOrdersReportQueryHandler(
            IRepository<Domain.Entities.OrdersDetails> ordersDetailsRepo,
            IMapper mapper)
        {
            _ordersDetailsRepo = ordersDetailsRepo ?? throw new ArgumentNullException(nameof(ordersDetailsRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response<IEnumerable<GetOrdersReportDto>>> Handle(GetOrdersReportQuery request, CancellationToken cancellationToken)
        {
            var ordersReport = await _ordersDetailsRepo.GetAsQueryable()
                .Include(i => i.Orders)
                .Include(i => i.Product)
                .OrderByDescending(o => o.OrdersID)
                .Select(a => new GetOrdersReportDto()
                {
                    OrdersId = a.OrdersID,
                    POExternal = a.Orders.POExternal,
                    POInternal = a.Orders.POInternal,
                    ReceivedDate = a.Orders.ReceivedDate,
                    ProductName = a.Product.ProductName,
                    QtyOrdered = a.QtyOrdered,
                    EntryDate = a.EntryDate,
                    DueDate = a.DueDate
                }).ToListAsync();

            return new Response<IEnumerable<GetOrdersReportDto>>(ordersReport);

        }
    }
}
