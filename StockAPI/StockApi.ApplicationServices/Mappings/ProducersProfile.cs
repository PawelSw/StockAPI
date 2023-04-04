using AutoMapper;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockApi.ApplicationServices.API.Domain.SupplierServices;

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

            this.CreateMap<DeleteProducerRequest, StockAPI.DataAccess.Entities.Producer>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.DeleteId));

            this.CreateMap<UpdateProducerRequest, StockAPI.DataAccess.Entities.Producer>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.UpdateId))
           .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
        }
    }
}
