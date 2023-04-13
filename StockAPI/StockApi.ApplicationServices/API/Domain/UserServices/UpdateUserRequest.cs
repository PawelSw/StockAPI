using MediatR;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using StockAPI.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace StockApi.ApplicationServices.API.Domain.UserServices
{
    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public int UpdateId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
     
        public string UserName { get; set; }
   
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
