using MediatR;


namespace StockApi.ApplicationServices.API.Domain.SupplierServices
{
    public class AddSupplierRequest : IRequest<AddSupplierResponse>
    {
        public string Name { get; set; }
        public string Address { get; set; }

    }


}
