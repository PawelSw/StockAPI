using MediatR;

namespace StockApi.ApplicationServices.API.Domain.ProducerService
{
    public class AddProducerRequest : IRequest<AddProducerResponse>
    {
        public string Name { get; set; }
    }
}
