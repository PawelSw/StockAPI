using MediatR;
using StockApi.ApplicationServices.API.Domain.ProducerService;

namespace StockApi.ApplicationServices.API.Domain.SupplierServices
{
    public class GetSupplierByNameRequest : IRequest<GetSupplierByNameResponse>
    {
        public string Name { get; set; }
    }
}
