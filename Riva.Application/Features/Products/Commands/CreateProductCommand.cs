using AutoMapper;
using MediatR;
using Riva.Application.DTOs.Products;
using Riva.Application.Features.Products.Events.Notifications;
using Riva.Application.Interfaces;
using Riva.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Riva.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<Response<int>>
    {
        public CreateProductDto Product { get; private set; }
        public CreateProductCommand(CreateProductDto product)
        {
            Product = product;
        }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<int>>
    {
        private readonly IRepository<Domain.Entities.Products> _productsRepo;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CreateProductCommandHandler(
            IRepository<Domain.Entities.Products> productsRepo,
            IMapper mapper,
            IMediator mediator
            )
        {
            _productsRepo = productsRepo ?? throw new ArgumentNullException(nameof(productsRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<Response<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<Domain.Entities.Products>(request.Product);

            await _productsRepo.AddAsync(newProduct);

            await _mediator.Publish(new OnProductCreated(newProduct.ProductsID));

            return new Response<int>(newProduct.ProductsID);
        }
    }
}
