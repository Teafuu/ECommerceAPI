using Application.Commands.V1.Order;
using Application.Commands.V1.Product;
using Application.Commands.V1.User;
using AutoMapper;
using Repositories.Models;

namespace Application.Commands
{
    public class ConfigureModelMaps : Profile
    {
        public ConfigureModelMaps()
        {
            CreateMap<CreateProduct.Request, Product>();
            CreateMap<CreateUser.Request, User>();
            CreateMap<CreateOrder.Request, Order>();
        }
    }
}
