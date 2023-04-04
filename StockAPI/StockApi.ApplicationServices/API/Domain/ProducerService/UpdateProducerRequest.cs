using MediatR;

namespace StockApi.ApplicationServices.API.Domain.ProducerService
{
    public class UpdateProducerRequest : IRequest<UpdateProducerResponse>
    {
        public int UpdateId { get; set; }
        public string Name { get; set; }
    }
}
