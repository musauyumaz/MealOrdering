using AutoMapper;
using MealOrdering.Server.Data.Models;
using MealOrdering.Shared.DTOs;

namespace MealOrdering.Server.Services.Extensions
{
    public static class ConfigureMappingExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection services)
        {
            MapperConfiguration mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;
            AllowNullCollections = true;

            CreateMap<Supplier, SupplierDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>()
                .ForMember(o => o.SupplierName, od => od.MapFrom(o => o.Supplier.Name))
                .ForMember(o => o.CreatedUserFullName, od => od.MapFrom(o => $"{o.User.FirstName} {o.User.LastName}"));

            CreateMap<OrderDTO, Order>();

            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(oi => oi.CreatedUserFullName, oid => oid.MapFrom(oi => $"{oi.User.FirstName} {oi.User.LastName}"))
                .ForMember(oi => oi.OrderName, oid => oid.MapFrom(oi => oi.Order.Name ?? ""));

            CreateMap<OrderItemDTO, OrderItem>();


        }
    }
}

