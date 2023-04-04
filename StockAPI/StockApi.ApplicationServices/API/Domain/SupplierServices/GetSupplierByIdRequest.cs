using MediatR;
using StockApi.ApplicationServices.API.Domain.ProducerService;

namespace StockApi.ApplicationServices.API.Domain.SupplierServices
{
    public class GetSupplierByIdRequest : IRequest<GetSupplierByIdResponse>
    {
        public int SupplierId { get; set; }
    }
}
