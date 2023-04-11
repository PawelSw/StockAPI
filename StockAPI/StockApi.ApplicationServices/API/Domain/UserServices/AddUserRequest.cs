using MediatR;


namespace StockApi.ApplicationServices.API.Domain.UserServices
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
