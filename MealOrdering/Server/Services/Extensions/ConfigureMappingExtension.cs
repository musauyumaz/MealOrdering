using AutoMapper;
using MealOrdering.Server.Data.Models;
using MealOrdering.Shared.DTO;

namespace MealOrdering.Server.Services.Extensions
{
    public static class ConfigureMappingExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
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
                .ForMember(x => x.SupplierName, y => y.MapFrom(z => z.Supplier.Name))
                .ForMember(x => x.UserFullName, y => y.MapFrom(z => $"{z.User.FirstName} {z.User.LastName}"));
            CreateMap<OrderDTO, Order>();

            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(x => x.UserFullName, y => y.MapFrom(z => $"{z.User.FirstName} {z.User.LastName}"))
                .ForMember(x => x.OrderName, y => y.MapFrom(z => z.Order.Name ?? ""));
            CreateMap<OrderItemDTO, OrderItem>();
        }
    }
}
