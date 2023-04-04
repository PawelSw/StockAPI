using MediatR;
using StockApi.ApplicationServices.API.Domain.ItemServices;

namespace StockApi.ApplicationServices.API.Domain.ProducerService
{
    public class GetProducerByNameRequest : IRequest<GetProducerByNameResponse>
    {
        public string Name { get; set; }
    }
}
