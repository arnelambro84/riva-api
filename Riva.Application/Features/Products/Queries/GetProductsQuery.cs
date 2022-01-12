using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Riva.Application.DTOs.Products;
using Riva.Application.Interfaces;
using Riva.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Riva.Application.Features.Products.Queries
{
    public class GetProductsQuery : IRequest<Response<IEnumerable<GetProductsDto>>>
    {
        //To Do: include search and paging parameters
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Response<IEnumerable<GetProductsDto>>>
    {
        private readonly IRepository<Domain.Entities.Products> _productsRepo;
        private readonly IMapper _mapper;
        public GetProductsQueryHandler(
            IRepository<Domain.Entities.Products> productsRepo,
            IMapper mapper)
        {
            _productsRepo = productsRepo ?? throw new ArgumentNullException(nameof(productsRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Response<IEnumerable<GetProductsDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productsRepo.GetAsQueryable()
                .OrderBy(a => a.ProductName)
                .Select(x => _mapper.Map<GetProductsDto>(x))
                .ToListAsync();

            return new Response<IEnumerable<GetProductsDto>>(products);
        }
    }

}
