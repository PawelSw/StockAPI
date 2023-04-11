using MediatR;
using StockApi.ApplicationServices.API.Domain.ItemServices;

namespace StockApi.ApplicationServices.API.Domain.UserServices
{
    public class GetUserByNameRequest : IRequest<GetUserByNameResponse>
    {
        public string UserName { get; set; }
    }
}
