using MediatR;
using StockApi.ApplicationServices.API.Domain.ItemServices;

namespace StockApi.ApplicationServices.API.Domain.ProducerService
{
    public class GetProducerByIdRequest : IRequest<GetProducerByIdResponse>
    {
        public int ProducerId { get; set; }

    }
}
