using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ProducerService;
using StockApi.ApplicationServices.API.Domain.SupplierServices;
using StockAPI.DataAccess.CQRS.Commands.ProducersCommand;
using StockAPI.DataAccess.CQRS.Querries.ProducersQuerry;
using StockAPI.DataAccess.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockAPI.DataAccess.CQRS.Querries.SuppliersQuerry;
using StockAPI.DataAccess.CQRS.Commands.SuppliersCommand;
using StockApi.ApplicationServices.API.ErrorHandling;

namespace StockApi.ApplicationServices.API.Handlers.Suppliershandler
{
    internal class DeleteSupplierHandler : IRequestHandler<DeleteSupplierRequest, DeleteSupplierResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQuerryExecutor _querryExecutor;

        public DeleteSupplierHandler(IMapper mapper,
            ICommandExecutor commandExecutor,
            IQuerryExecutor querryExecutor)
        {
            _mapper = mapper;
            _commandExecutor = commandExecutor;
            _querryExecutor = querryExecutor;
        }
        public async Task<DeleteSupplierResponse> Handle(DeleteSupplierRequest request, CancellationToken cancellationToken)
        {
            var query = new GetSupplierByIdQuerry()
            {
                Id = request.DeleteId
            };
            var supplier = await _querryExecutor.Execute(query);

            if (supplier is null)
            {
                return new DeleteSupplierResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedSupplier = _mapper.Map<StockAPI.DataAccess.Entities.Supplier>(request);
            var command = new DeleteSupplierCommand()
            {
                Parameter = mappedSupplier
            };
            var deleteSupplier = await _commandExecutor.Execute(command);
            var response = new DeleteSupplierResponse()
            {
                Data = _mapper.Map<Domain.Models.Supplier>(deleteSupplier)
            };
            return response;
        }
    }
}
