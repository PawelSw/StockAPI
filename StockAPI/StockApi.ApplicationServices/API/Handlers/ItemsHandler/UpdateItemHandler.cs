using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockAPI.DataAccess.CQRS;
using StockAPI.DataAccess.CQRS.Commands.ItemsCommand;
using StockAPI.DataAccess.CQRS.Querries.ItemsQuerry;

namespace StockApi.ApplicationServices.API.Handlers.ItemsHandler
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemRequest, UpdateItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuerryExecutor _queryExecutor;
        private readonly ICommandExecutor _commandExecutor;

        public UpdateItemHandler(
            IMapper mapper,
            IQuerryExecutor queryExecutor,
            ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
            _commandExecutor = commandExecutor;
        }

        public async Task<UpdateItemResponse> Handle(UpdateItemRequest request, CancellationToken cancellationToken)
        {
            var query = new GetItemByIdQuerry()
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

            var mappedProduct = _mapper.Map<StockAPI.DataAccess.Entities.Item>(request);

            var command = new UpdateItemCommand()
            {
                Parameter = mappedProduct,
            };

            var updatedProduct = await _commandExecutor.Execute(command);

            var response = new UpdateItemResponse()
            {
                Data = _mapper.Map<Domain.Models.Item>(updatedProduct)
            };

            return response;
        }
    }
}
