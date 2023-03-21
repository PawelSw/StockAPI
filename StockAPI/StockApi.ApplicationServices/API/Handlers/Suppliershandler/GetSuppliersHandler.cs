using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using StockAPI.DataAccess;
using StockAPI.DataAccess.Entities;

namespace StockApi.ApplicationServices.API.Handlers.Suppliershandler
{
    public class GetSuppliersHandler : IRequestHandler<GetSuppliersRequest, GetSuppliersResponse>
    {
        private readonly IRepository<Supplier> supplierRepository;
        private readonly IMapper mapper;
        public GetSuppliersHandler(IRepository<Supplier> supplierRepository, IMapper mapper)
        {
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }
        public Task<GetSuppliersResponse> Handle(GetSuppliersRequest request, CancellationToken cancellationToken)
        {
            var suppliers = this.supplierRepository.GetAll();
            var mappedSuppliers = this.mapper.Map<List<Domain.Models.Supplier>>(suppliers);
   
            var response = new GetSuppliersResponse()
            {
                Data = mappedSuppliers,
            };
            return Task.FromResult(response);

        }

    }
}
