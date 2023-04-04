using MediatR;
using StockApi.ApplicationServices.API.Domain.ProducerService;

namespace StockApi.ApplicationServices.API.Domain.SupplierServices
{
    public class DeleteSupplierRequest : IRequest<DeleteSupplierResponse>
    {
        public int DeleteId { get; set; }
    }
}
