using MediatR;
using StockAPI.DataAccess.Enums;

namespace StockApi.ApplicationServices.API.Domain.UserServices
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

    }
}
