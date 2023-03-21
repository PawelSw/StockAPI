using AutoMapper;
using StockApi.ApplicationServices.API.Domain.ProducerService;

namespace StockApi.ApplicationServices.Mappings
{
    public class ProducersProfile : Profile
    {
        public ProducersProfile()
        {
            this.CreateMap<AddProducerRequest, StockAPI.DataAccess.Entities.Producer>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));



            this.CreateMap<StockAPI.DataAccess.Entities.Producer, API.Domain.Models.Producer>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));           
        }
    }
}
