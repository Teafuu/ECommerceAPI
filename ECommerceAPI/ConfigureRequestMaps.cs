using System.Reflection;
using Application.Commands.V1.Product;
using Application.Commands.V1.User;
using AutoMapper;
using ECommerceAPI.Models.Dto.Request.Product;
using ECommerceAPI.Models.Dto.Request.User;

namespace ECommerceAPI
{
    public class ConfigureRequestMaps : Profile
    {
        public ConfigureRequestMaps()
        {
            CreateMap<CreateUserRequest, CreateUser.Request>();
            CreateMap<ValidateCredentialsRequest, ValidateUser.Request>();

            CreateMap<CreateProductRequest, CreateProduct.Request>();
            CreateMap<PatchProductRequest, PatchProduct.Request>();
        }
    }
}
