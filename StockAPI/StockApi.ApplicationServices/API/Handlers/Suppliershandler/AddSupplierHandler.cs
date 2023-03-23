using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using StockAPI.DataAccess.CQRS;
using StockAPI.DataAccess.CQRS.Commands.SuppliersCommand;
using StockAPI.DataAccess.Entities;

namespace StockApi.ApplicationServices.API.Handlers.Suppliershandler
{
    public class AddSupplierHandler : IRequestHandler<AddSupplierRequest,AddSupplierResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        public AddSupplierHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddSupplierResponse> Handle(AddSupplierRequest request, CancellationToken cancellationToken)
        {
            var supplier = this.mapper.Map<Supplier>(request);
            var command = new AddSupplierCommand() { Parameter = supplier };
            var supplierFromDB = await this.commandExecutor.Execute(command);
            return new AddSupplierResponse()
            {
                Data = this.mapper.Map<Domain.Models.Supplier>(supplierFromDB),
            };
        }
    }
}
