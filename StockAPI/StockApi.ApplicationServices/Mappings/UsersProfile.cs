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
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
            .ForMember(x => x.Role, y => y.MapFrom(z => z.Role));

            this.CreateMap<AddUserRequest, StockAPI.DataAccess.Entities.User>()
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
            .ForMember(x => x.Role, y => y.MapFrom(z => z.Role));

            this.CreateMap<DeleteUserRequest, StockAPI.DataAccess.Entities.User>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.DeleteId));

            this.CreateMap<UpdateUserRequest, StockAPI.DataAccess.Entities.User>()
           .ForMember(x => x.Id, y => y.MapFrom(z => z.UpdateId))
           .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
           .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
           .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
           .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
           .ForMember(x => x.Role, y => y.MapFrom(z => z.Role));


        }
    }
}
