using MediatR;


namespace StockApi.ApplicationServices.API.Domain.SupplierServices
{
    public class UpdateSupplierRequest : IRequest<UpdateSupplierResponse>
    {
        public int UpdateId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
