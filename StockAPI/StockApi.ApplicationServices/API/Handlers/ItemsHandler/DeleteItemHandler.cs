using AutoMapper;
using MediatR;
using StockApi.ApplicationServices.API.Domain.ItemServices;
using StockAPI.DataAccess.CQRS.Commands.ItemsCommand;
using StockAPI.DataAccess.CQRS.Querries.ItemsQuerry;
using StockAPI.DataAccess.CQRS;

namespace StockApi.ApplicationServices.API.Handlers.ItemsHandler
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemRequest, DeleteItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQuerryExecutor _querryExecutor;

        public DeleteItemHandler(IMapper mapper,
            ICommandExecutor commandExecutor,
            IQuerryExecutor querryExecutor)
        {
            _mapper = mapper;
            _commandExecutor = commandExecutor;
            _querryExecutor = querryExecutor;
        }
        public async Task<DeleteItemResponse> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
        {
            var query = new GetItemByIdQuerry()
            {
                Id = request.DeleteId
            };
            var product = await _querryExecutor.Execute(query);

            //if (product is null)
            //{
            //    return new DeleteProductResponse()
            //    {
            //        Error = new ErrorModel(ErrorType.NotFound)
            //    };
            //}

            var mappeditem = _mapper.Map<StockAPI.DataAccess.Entities.Item>(request);
            var command = new DeleteItemCommand()
            {
                Parameter = mappeditem
            };
            var deleteItem = await _commandExecutor.Execute(command);
            var response = new DeleteItemResponse()
            {
                Data = _mapper.Map<Domain.Models.Item>(deleteItem)
            };
            return response;
        }
    }
}
