using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using StockAPI.DataAccess.CQRS.Commands.SuppliersCommand;
using StockAPI.DataAccess.CQRS.Querries.ItemsQuerry;
using StockAPI.DataAccess.CQRS;
using StockAPI.DataAccess.CQRS.Querries.SuppliersQuerry;

namespace StockApi.ApplicationServices.API.Handlers.Suppliershandler
{
    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplierRequest, UpdateSupplierResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuerryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public UpdateSupplierHandler(
            IMapper mapper,
            IQuerryExecutor queryExecutor,
            ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public async Task<UpdateSupplierResponse> Handle(UpdateSupplierRequest request, CancellationToken cancellationToken)
        {
            var query = new GetSupplierByIdQuerry()
            {
                Id = request.UpdateId
            };
            //var product = await _queryExecutor.Execute(query);

            //if (product is null)
            //{
            //    return new UpdateProductResponse()
            //    {
            //        Error = new ErrorModel(ErrorType.NotFound)
            //    };
            //}

            var mappedSupplier = _mapper.Map<StockAPI.DataAccess.Entities.Supplier>(request);

            var command = new UpdateSupplierCommand()
            {
                Parameter = mappedSupplier,
            };

            var updatedSupplier = await _commandExecutor.Execute(command);

            var response = new UpdateSupplierResponse()
            {
                Data = _mapper.Map<Domain.Models.Supplier>(updatedSupplier)
            };

            return response;
        }
    }
}
