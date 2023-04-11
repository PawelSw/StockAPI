using MediatR;
using StockApi.ApplicationServices.API.Domain.ProducerService;

namespace StockApi.ApplicationServices.API.Domain.UserServices
{
    public class GetUsersRequest : IRequest<GetUsersResponse>
    {
    }
}
