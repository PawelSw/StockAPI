using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using StockAPI.DataAccess.CQRS.Querries.ProducersQuerry;
using StockAPI.DataAccess.CQRS;
using StockAPI.DataAccess.CQRS.Querries.SuppliersQuerry;

namespace StockApi.ApplicationServices.API.Handlers.Suppliershandler
{
    public class GetSupplierByIdHandler : IRequestHandler<GetSupplierByIdRequest, GetSupplierByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQuerryExecutor querryExecutor;
        public GetSupplierByIdHandler(IMapper mapper, IQuerryExecutor querryExecutor)
        {
            this.mapper = mapper;
            this.querryExecutor = querryExecutor;
        }
        public async Task<GetSupplierByIdResponse> Handle(GetSupplierByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetSupplierByIdQuerry()
            {
                Id = request.SupplierId
            };
            var supplier = await querryExecutor.Execute(query);
            var mappedSuppliers = mapper.Map<Domain.Models.Supplier>(supplier);

            var response = new GetSupplierByIdResponse()
            {
                Data = mappedSuppliers
            };

            return response;

        }
    }
}
