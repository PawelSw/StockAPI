using AutoMapper;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockApi.ApplicationServices.API.Domain.Models;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockAPI.DataAccess.Entities;

namespace StockApi.ApplicationServices.Mappings
{
    public class ItemsProfile : Profile
    {
        public ItemsProfile()
        {
            this.CreateMap<AddItemRequest, StockAPI.DataAccess.Entities.Item>()
            .ForMember(x => x.ItemName, y => y.MapFrom(z => z.ItemName))
            .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
            .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
            .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity))
            .ForMember(x => x.SupplierId, y => y.MapFrom(z => z.SupplierId));


            this.CreateMap<StockAPI.DataAccess.Entities.Item, API.Domain.Models.Item>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.ItemName, y => y.MapFrom(z => z.ItemName))
            .ForMember(x => x.Category, y => y.MapFrom(z => z.Category));

            this.CreateMap<DeleteItemRequest, StockAPI.DataAccess.Entities.Item>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.DeleteId));

            this.CreateMap<UpdateItemRequest, StockAPI.DataAccess.Entities.Item>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.UpdateId))
            .ForMember(x => x.ItemName, y => y.MapFrom(z => z.ItemName))
            .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
            .ForMember(x => x.SupplierId, y => y.MapFrom(z => z.SupplierId));
        }
    }
}
