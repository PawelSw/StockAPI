using AutoMapper;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using StockApi.ApplicationServices.API.Domain.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApi.ApplicationServices.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<StockAPI.DataAccess.Entities.User, API.Domain.Models.User>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName));


            this.CreateMap<AddUserRequest, StockAPI.DataAccess.Entities.User>()
           .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName));

        }
    }
}
