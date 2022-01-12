using AutoMapper;
using Riva.Application.DTOs.OrderDetails;
using Riva.Application.DTOs.Orders;
using Riva.Application.DTOs.Products;
using Riva.Domain.Entities;

namespace Riva.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Products, CreateProductDto>().ReverseMap();
            CreateMap<Products, UpdateProductDto>().ReverseMap();
            CreateMap<Products, GetProductsDto>();

            CreateMap<Orders, GetOrdersDto>().ReverseMap();
            CreateMap<Orders, CreateOrderDto>().ReverseMap();
            CreateMap<Orders, UpdateOrderDto>().ReverseMap();

            CreateMap<OrdersDetails, CreateOrderDetailsDto>().ReverseMap();

        }
    }
}