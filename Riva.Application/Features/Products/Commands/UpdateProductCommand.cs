using AutoMapper;
using MediatR;
using Riva.Application.DTOs.Products;
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
    public class UpdateProductCommand : IRequest<Response<bool>>
    {
        public UpdateProductDto Product { get; private set; }
        public UpdateProductCommand(UpdateProductDto product)
        {
            Product = product;
        }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<bool>>
    {
        private readonly IRepository<Domain.Entities.Products> _productsRepo;
        public UpdateProductCommandHandler(
            IRepository<Domain.Entities.Products> productsRepo)
        {
            _productsRepo = productsRepo ?? throw new ArgumentNullException(nameof(productsRepo));
        }
        public async Task<Response<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productsRepo.GetByIdAsync(request.Product.ProductsID);
            productToUpdate.ProductName = request.Product.ProductName;
            productToUpdate.SKU = request.Product.SKU;
            productToUpdate.CustomerSKU = request.Product.CustomerSKU;
            productToUpdate.ProductsTypeID = request.Product.ProductTypeID;
            productToUpdate.ProductDesc = request.Product.ProductDesc;
            productToUpdate.CustomerCode = request.Product.CustomerCode;
            productToUpdate.CommentBox = request.Product.CommentBox;
            productToUpdate.Status = request.Product.Status;
            productToUpdate.UOM = request.Product.UOM;
            productToUpdate.PicPath = request.Product.PicPath;
            productToUpdate.JewelryType = request.Product.JewelryType;

            await _productsRepo.UpdateAsync(productToUpdate);

            return new Response<bool>(true);

        }
    }
}
