using MediatR;

namespace StockApi.ApplicationServices.API.Domain.UserServices
{
    public class DeleteUserRequest : IRequest<DeleteUserResponse>
    {
        public int DeleteId { get; set; }
    }
}
