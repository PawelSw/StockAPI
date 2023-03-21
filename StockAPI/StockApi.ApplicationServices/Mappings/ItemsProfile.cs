using AutoMapper;
using StockApi.ApplicationServices.API.Domain.Models;
using StockAPI.DataAccess.Entities;

namespace StockApi.ApplicationServices.Mappings
{
    public class ItemsProfile : Profile
    {
        public ItemsProfile() 
        {
            this.CreateMap<StockAPI.DataAccess.Entities.Item, API.Domain.Models.Item>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.ItemName, y => y.MapFrom(z => z.ItemName))
            .ForMember(x => x.Category, y => y.MapFrom(z => z.Category));
        }
    }
}
