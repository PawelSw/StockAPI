using AutoMapper;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockApi.ApplicationServices.API.Domain.SupplierServices;

namespace StockApi.ApplicationServices.Mappings
{
    public class SuppliersProfile : Profile
    {
        public SuppliersProfile()
        {
            this.CreateMap<AddSupplierRequest, StockAPI.DataAccess.Entities.Supplier>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Address, y => y.MapFrom(z => z.Address));


            this.CreateMap<StockAPI.DataAccess.Entities.Supplier, API.Domain.Models.Supplier>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Address, y => y.MapFrom(z => z.Address));

            this.CreateMap<DeleteSupplierRequest, StockAPI.DataAccess.Entities.Supplier>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.DeleteId));

            this.CreateMap<UpdateSupplierRequest, StockAPI.DataAccess.Entities.Supplier>()
          .ForMember(x => x.Id, y => y.MapFrom(z => z.UpdateId))
          .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
          .ForMember(x => x.Address, y => y.MapFrom(z => z.Address));
         
        }
    }
}
