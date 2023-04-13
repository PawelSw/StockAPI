using MediatR;
using StockApi.ApplicationServices.API.Domain.SupplierServices;

namespace StockApi.ApplicationServices.API.Domain.UserServices
{
    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public int UserId { get; set; }
    }
}
