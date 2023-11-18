
using AutoMapper;
using Restaurant.Core.Application.Dtos.Dish;
using Restaurant.Core.Application.Dtos.Ingredient;
using Restaurant.Core.Application.Dtos.Order;
using Restaurant.Core.Application.Dtos.Table;
using Restaurant.Core.Application.Enums;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {
            #region Ingredients
            CreateMap<Ingredient, IngredientRequest>()
                .ReverseMap()
                .ForMember(x => x.IngredientId, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedAt, opt => opt.Ignore());

            CreateMap<Ingredient, IngredientUpdRequest>()
                .ReverseMap()
                .ForMember(x => x.IngredientId, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedAt, opt => opt.Ignore());

            CreateMap<Ingredient, IngredientResponse>()
                .ReverseMap()
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedAt, opt => opt.Ignore());
            #endregion

            #region Dish
            CreateMap<Dish, DishRequest>()
                .ForMember(x => x.Category, opt => opt.MapFrom(src => (DishCategory)src.CategoryId))
                .ForMember(x => x.Ingredients, opt => opt.MapFrom(src => src.Ingredients.Select(i => i.IngredientId)))
                .ReverseMap()
                .ForMember(x => x.DishId, opt => opt.Ignore())
                .ForMember(x => x.CategoryId, opt => opt.MapFrom(src => (int)src.Category))
                .ForMember(x => x.Ingredients, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedAt, opt => opt.Ignore());

            CreateMap<Dish, DishUpdRequest>()
                .ForMember(x => x.Ingredients, opt => opt.MapFrom(src => src.Ingredients.Select(i => i.IngredientId)))
                .ReverseMap()
                .ForMember(x => x.DishId, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedAt, opt => opt.Ignore());

            CreateMap<Dish, DishResponse>()
                .ForMember(x => x.Category, opt => opt.MapFrom(src => Enum.GetName(typeof(DishCategory), src.CategoryId)))
                .ReverseMap()
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedAt, opt => opt.Ignore());
            #endregion

            #region Table
            CreateMap<Table, TableRequest>()
                .ReverseMap()
                .ForMember(x => x.TableId, opt => opt.Ignore())
                .ForMember(x => x.StatusId, opt => opt.MapFrom(src => TableStatus.Available))
                .ForMember(x => x.Orders, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedAt, opt => opt.Ignore());

            CreateMap<Table, TableUpdRequest>()
                .ReverseMap()
                .ForMember(x => x.TableId, opt => opt.Ignore())
                .ForMember(x => x.Orders, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedAt, opt => opt.Ignore());

            CreateMap<Table, TableStatusRequest>()
                .ReverseMap()
                .ForMember(x => x.TableId, opt => opt.Ignore())
                .ForMember(x => x.Description, opt => opt.Ignore())
                .ForMember(x => x.Capacity, opt => opt.Ignore())
                .ForMember(x => x.Orders, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedAt, opt => opt.Ignore());

            CreateMap<Table, TableResponse>()
                .ForMember(x => x.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(TableStatus), src.StatusId)))
                .ReverseMap()
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedAt, opt => opt.Ignore());
            #endregion

            #region Order
            CreateMap<OrderRequest, Order>()
                .ForMember(x => x.Dishes, opt => opt.Ignore());

            CreateMap<Order, OrderUpdRequest>()
                .ReverseMap()
                .ForMember(x => x.Table, opt => opt.Ignore())
                .ForMember(x => x.TableId, opt => opt.Ignore())
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedAt, opt => opt.Ignore());

            CreateMap<Order, OrderResponse>()
                .ForMember(x => x.Status, opt => opt.MapFrom(src => Enum.GetName(typeof(OrderStatus), src.StatusId)))
                .ReverseMap()
                .ForMember(x => x.CreatedAt, opt => opt.Ignore())
                .ForMember(x => x.LastModifiedAt, opt => opt.Ignore());

            CreateMap<Table, TableOrderResponse>()
                .ForMember(x => x.Orders, opt => opt.MapFrom(src => src.Orders));
            #endregion
        }
    }
}
