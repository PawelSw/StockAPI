using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using StockAPI.DataAccess.CQRS.Querries.ProducersQuerry;
using StockAPI.DataAccess.CQRS;
using StockAPI.DataAccess.CQRS.Querries.SuppliersQuerry;

namespace StockApi.ApplicationServices.API.Handlers.Suppliershandler
{
    public class GetSupplierByNameHandler : IRequestHandler<GetSupplierByNameRequest, GetSupplierByNameResponse>
    {
        private readonly IMapper mapper;
        private readonly IQuerryExecutor querryExecutor;
        public GetSupplierByNameHandler(IMapper mapper, IQuerryExecutor querryExecutor)
        {
            this.mapper = mapper;
            this.querryExecutor = querryExecutor;
        }
        public async Task<GetSupplierByNameResponse> Handle(GetSupplierByNameRequest request, CancellationToken cancellationToken)
        {
            var query = new GetSupplierByNameQuerry()
            {
                Name = request.Name,
            };
            var suppliers = await querryExecutor.Execute(query);
            var mappedSuppliers = mapper.Map<List<Domain.Models.Supplier>>(suppliers);

            var response = new GetSupplierByNameResponse()
            {
                Data = mappedSuppliers
            };

            return response;

        }
    }
}
