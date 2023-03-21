using AutoMapper;

namespace StockApi.ApplicationServices.Mappings
{
    public class SuppliersProfile : Profile
    {
        public SuppliersProfile()
        {
            this.CreateMap<StockAPI.DataAccess.Entities.Supplier, API.Domain.Models.Supplier>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Address, y => y.MapFrom(z => z.Address));
        }
    }
}
