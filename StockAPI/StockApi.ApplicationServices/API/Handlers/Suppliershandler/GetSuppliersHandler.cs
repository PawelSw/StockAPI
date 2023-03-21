using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using StockAPI.DataAccess;
using StockAPI.DataAccess.CQRS;
using StockAPI.DataAccess.CQRS.Querries.SuppliersQuerry;
using StockAPI.DataAccess.Entities;

namespace StockApi.ApplicationServices.API.Handlers.Suppliershandler
{
    public class GetSuppliersHandler : IRequestHandler<GetSuppliersRequest, GetSuppliersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQuerryExecutor querryExecutor;
        public GetSuppliersHandler(IMapper mapper, IQuerryExecutor querryExecutor)
        {
            this.mapper = mapper;
            this.querryExecutor = querryExecutor;
        }
        public async Task<GetSuppliersResponse> Handle(GetSuppliersRequest request, CancellationToken cancellationToken)
        {
            var querry = new GetSuppliersQuerry();
            var suppliers = await querryExecutor.Execute(querry);
            var mappedSuppliers = this.mapper.Map<List<Domain.Models.Supplier>>(suppliers);
   
            var response = new GetSuppliersResponse()
            {
                Data = mappedSuppliers,
            };
            return response;

        }

    }
}
