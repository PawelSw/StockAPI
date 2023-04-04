using MediatR;


namespace StockApi.ApplicationServices.API.Domain.ProducerService
{
    public class DeleteProducerRequest : IRequest<DeleteProducerResponse>
    {
        public int DeleteId { get; set; }
    }
}
