using MediatR;
using Microsoft.EntityFrameworkCore;
using Riva.Application.DTOs.OrderDetails;
using Riva.Application.Interfaces;
using Riva.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace Riva.Application.Features.OrderDetails.Queries
{
    public class GetOrderDetailsQuery : IRequest<Response<IEnumerable<GetOrderDetailsDto>>>
    {
        public int OrderId { get; private set; }
        public GetOrderDetailsQuery(int orderId)
        {
            OrderId = orderId;
        }
    }

    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, Response<IEnumerable<GetOrderDetailsDto>>>
    {
        private readonly IRepository<Domain.Entities.OrdersDetails> _orderDetailsRepo;
        public GetOrderDetailsQueryHandler(IRepository<Domain.Entities.OrdersDetails> orderDetailsRepo)
        {
            _orderDetailsRepo = orderDetailsRepo ?? throw new ArgumentNullException(nameof(orderDetailsRepo));
        }
        public async Task<Response<IEnumerable<GetOrderDetailsDto>>> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = await _orderDetailsRepo.GetAsQueryable()
                .Include(i => i.Product)
                .Where(x => x.OrdersID == request.OrderId)
                .Select(s => new GetOrderDetailsDto()
                {
                    OrderDetailsID = s.OrdersDetailsID,
                    OrdersID = s.OrdersID,
                    ProductsID = s.ProductsID,
                    ProductsInfoID = s.ProductsInfoID,
                    QtyOrdered = s.QtyOrdered,
                    QtyShipped = s.QtyShipped,
                    QtyInvoiced = s.QtyInvoiced,
                    EntryDate = s.EntryDate,
                    DueDate = s.DueDate,
                    CustAddrsID = s.CustAdrsID,
                    Comment = s.Comment,
                    Product = new DTOs.Products.ProductDetailsDto()
                    {
                        ProductName = s.Product.ProductName,
                        ProductDesc = s.Product.ProductDesc
                    }
                })
                .ToListAsync();

            return new Response<IEnumerable<GetOrderDetailsDto>>(orderDetails);
        }
    }
}
