using MediatR;
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
    public class DeleteProductCommand : IRequest<Response<bool>>
    {
        public int ProductId { get; private set; }
        public DeleteProductCommand(int productId)
        {
            ProductId = productId;
        }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response<bool>>
    {
        private readonly IRepository<Domain.Entities.Products> _productsRepo;
        public DeleteProductCommandHandler(
            IRepository<Domain.Entities.Products> productsRepo)
        {
            _productsRepo = productsRepo ?? throw new ArgumentNullException(nameof(productsRepo));
        }

        public async Task<Response<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _productsRepo.GetByIdAsync(request.ProductId);

            //To Do: Apply business rule if the product exist in Order details table

            await _productsRepo.DeleteAsync(productToDelete);

            return new Response<bool>(true);
        }
    }
}
